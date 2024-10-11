import json
import pandas as pd
import plotly.graph_objects as go
import os
from datetime import datetime
from colorama import init, Fore, Style

init(autoreset=True)

with open('Scripts/deposit_data.json', 'r') as f:
    deposit_data = json.load(f)

all_data = []
for deposit in deposit_data:
    for history in deposit['Histories']:
        all_data.append({
            'DepositName': deposit['DepositName'],
            'Date': history['Date'],
            'PreviousDeposit': history.get('PreviousDeposit', 0), 
            'ActualDeposit': history['ActualDeposit'],
            'CreatedDate': deposit['CreatedDate'] 
        })
    
    all_data.append({
        'DepositName': deposit['DepositName'],
        'Date': deposit['LastUpdatedDate'],
        'ActualDeposit': deposit['Balance'],
        'CreatedDate': deposit['CreatedDate'] 
    })

df = pd.DataFrame(all_data)
df['Date'] = pd.to_datetime(df['Date'])

df['CreatedDate'] = pd.to_datetime(df['CreatedDate'], errors='coerce')

output_dir = 'wwwroot/Graphs'
os.makedirs(output_dir, exist_ok=True)

def plot_deposit_history(deposit_name, df):
    try:
        deposit_df = df[df['DepositName'] == deposit_name]
        
        if deposit_df.empty:
            print(f"{Fore.YELLOW}[WARNING] Brak danych dla depozytu: {deposit_name}")
            return

        x_data = []
        y_data = []

        first_record = deposit_df.iloc[0]
        created_date = first_record['CreatedDate']

        if pd.isna(created_date):
            print(f"{Fore.RED}[ERROR] Data utworzenia (CreatedDate) jest pusta dla {deposit_name}")
            return

        print(f"{Fore.GREEN}[INFO] Data utworzenia: {created_date}")
        x_data.append(created_date) 
        y_data.append(first_record['PreviousDeposit']) 

        x_data.append(first_record['Date'])
        y_data.append(first_record['ActualDeposit']) 

        for i in range(1, len(deposit_df)):
            x_data.append(deposit_df.iloc[i]['Date'])
            y_data.append(deposit_df.iloc[i]['ActualDeposit'])

        fig = go.Figure()
        fig.add_trace(go.Scatter(
            x=x_data,
            y=y_data,
            mode='lines+markers',
            name=f'Balance History for {deposit_name}'
        ))

        fig.update_layout(
            title=f'Balance History for {deposit_name}',
            xaxis_title='Date',
            yaxis_title='Balance',
            hovermode="x",
            height=700,
            width=1000,
            margin=dict(l=20, r=20, t=40, b=40),
            legend=dict(x=0, y=1),
            showlegend=True,
            plot_bgcolor='#121212',
            paper_bgcolor='#121212',
            font=dict(color='#e0e0e0'),
            xaxis=dict(showgrid=False, color='#e0e0e0'),
            yaxis=dict(showgrid=True, gridcolor='#333333', color='#e0e0e0')
        )

        safe_deposit_name = deposit_name.replace(" ", "_")
        file_name = f'{output_dir}/{safe_deposit_name}_history.html'
        fig.write_html(file_name)
        print(f"{Fore.GREEN}[INFO] Wykres zapisany: {file_name}")
    except Exception as e:
        print(f"{Fore.RED}[ERROR] Błąd podczas generowania wykresu dla depozytu {deposit_name}: {str(e)}")

deposit_names = df['DepositName'].unique()
print(f"{Fore.GREEN}[INFO] Generowanie wykresów dla {len(deposit_names)} depozytów...")
for name in deposit_names:
    plot_deposit_history(name, df)

try:
    df['Month'] = df['Date'].dt.to_period('M')

    df_sorted = df.sort_values('Date').drop_duplicates(['DepositName', 'Month'], keep='last')

    df_grouped = df_sorted.groupby('Month').sum(numeric_only=True).reset_index()

    current_month = pd.Period(datetime.now(), freq='M') 
    current_sum = df_sorted[df_sorted['Month'] == current_month]['ActualDeposit'].sum()

    if current_month not in df_grouped['Month'].values:
        df_grouped = df_grouped.append({
            'Month': current_month,
            'ActualDeposit': current_sum
        }, ignore_index=True)

    fig = go.Figure()
    fig.add_trace(go.Scatter(
        x=df_grouped['Month'].dt.strftime('%Y-%m'),
        y=df_grouped['ActualDeposit'],
        mode='lines+markers',
        name='Total Balance'
    ))

    fig.update_layout(
        title='Total Balance Across All Deposits (Month by Month)',
        xaxis_title='Date',
        yaxis_title='Total Balance',
        hovermode="x",
        plot_bgcolor='#121212',
        paper_bgcolor='#121212',
        font=dict(color='#e0e0e0'),
        xaxis=dict(showgrid=False, color='#e0e0e0'),
        yaxis=dict(showgrid=True, gridcolor='#333333', color='#e0e0e0')
    )

    file_name = f'{output_dir}/total_balance_history.html'
    fig.write_html(file_name)
    print(f"{Fore.GREEN}[INFO] Wykres sumaryczny zapisany: {file_name}")

except Exception as e:
    print(f"{Fore.RED}[ERROR] Błąd podczas generowania sumarycznego wykresu: {str(e)}")
