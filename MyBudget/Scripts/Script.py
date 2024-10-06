import json
import pandas as pd
import matplotlib.pyplot as plt
import os

print("[INFO] Uruchomiono skrypt Pythona.")

with open('Scripts/deposit_data.json', 'r') as f:
    deposit_data = json.load(f)

print("[INFO] Dane załadowane z pliku JSON.")

all_data = []
for deposit in deposit_data:
    for history in deposit['Histories']:
        all_data.append({
            'DepositName': deposit['DepositName'],
            'Date': history['Date'],
            'PreviousDeposit': history['PreviousDeposit'],
            'Difference': history['Difference']
        })

if not all_data:
    print("[ERROR] Dane są puste. Skrypt kończy działanie.")
    exit()

df = pd.DataFrame(all_data)
df['Date'] = pd.to_datetime(df['Date'])

output_dir = 'wwwroot/Graphs'
os.makedirs(output_dir, exist_ok=True)
print(f"[INFO] Tworzenie wykresów w folderze: {output_dir}")

def plot_deposit_history(deposit_name, df):
    deposit_df = df[df['DepositName'] == deposit_name]
    plt.figure(figsize=(10, 6))
    plt.plot(deposit_df['Date'], deposit_df['PreviousDeposit'], marker='o')
    plt.title(f'Balance History for {deposit_name}')
    plt.xlabel('Date')
    plt.ylabel('Previous Deposit')
    plt.grid(True)
    file_name = f'{output_dir}/{deposit_name}_history.png'
    plt.savefig(file_name)
    print(f"[INFO] Wykres zapisany: {file_name}")

deposit_names = df['DepositName'].unique()
for name in deposit_names:
    plot_deposit_history(name, df)

df_grouped = df.groupby(pd.Grouper(key='Date', freq='ME')).sum()
plt.figure(figsize=(10, 6))
plt.plot(df_grouped.index, df_grouped['PreviousDeposit'], marker='o', color='r')
plt.title('Total Balance Across All Deposits (Month by Month)')
plt.xlabel('Date')
plt.ylabel('Total Balance')
plt.grid(True)
file_name = f'{output_dir}/total_balance_history.png'
plt.savefig(file_name)
print(f"[INFO] Wykres sumaryczny zapisany: {file_name}")
