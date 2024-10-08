import json
import pandas as pd
import plotly.graph_objects as go
import os

with open('Scripts/deposit_data.json', 'r') as f:
    deposit_data = json.load(f)

all_data = []
for deposit in deposit_data:
    for history in deposit['Histories']:
        all_data.append({
            'DepositName': deposit['DepositName'],
            'Date': history['Date'],
            'PreviousDeposit': history['PreviousDeposit'],
            'Difference': history['Difference']
        })
    
    all_data.append({
        'DepositName': deposit['DepositName'],
        'Date': deposit['LastUpdatedDate'],
        'PreviousDeposit': deposit['Balance'],
        'Difference': 0
    })

df = pd.DataFrame(all_data)
df['Date'] = pd.to_datetime(df['Date'])

output_dir = 'wwwroot/Graphs'
os.makedirs(output_dir, exist_ok=True)

def plot_deposit_history(deposit_name, df):
    try:
        deposit_df = df[df['DepositName'] == deposit_name]
        
        if deposit_df.empty:
            print(f"[WARNING] Brak danych dla depozytu: {deposit_name}")
            return
        
        fig = go.Figure()
        fig.add_trace(go.Scatter(
            x=deposit_df['Date'],
            y=deposit_df['PreviousDeposit'],
            mode='lines+markers',
            name=f'Balance History for {deposit_name}'
        ))

        fig.update_layout(
            title=f'Balance History for {deposit_name}',
            xaxis_title='Date',
            yaxis_title='Previous Deposit',
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
        print(f"[INFO] Wykres zapisany: {file_name}")
    except Exception as e:
        print(f"[ERROR] Błąd podczas generowania wykresu dla depozytu {deposit_name}: {str(e)}")

deposit_names = df['DepositName'].unique()
print(f"[INFO] Generowanie wykresów dla {len(deposit_names)} depozytów...")
for name in deposit_names:
    plot_deposit_history(name, df)

try:
    df_grouped = df.groupby(pd.Grouper(key='Date', freq='M')).sum()

    fig = go.Figure()
    fig.add_trace(go.Scatter(
        x=df_grouped.index,
        y=df_grouped['PreviousDeposit'],
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
    print(f"[INFO] Wykres sumaryczny zapisany: {file_name}")
except Exception as e:
    print(f"[ERROR] Błąd podczas generowania sumarycznego wykresu: {str(e)}")
