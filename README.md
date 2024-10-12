# MyBudget

## Project Overview

**MyBudget** is a personal finance management application designed to help users track account balances and visualize deposit histories through interactive charts. It offers an intuitive interface to help individuals manage their household finances and keep track of deposits over time.

## Features

- **Deposit Management**: Add, remove, and modify deposit names. Keep track of deposit balances and update their values.
- **Interactive Deposit History**: Generate interactive charts displaying the history of specific deposits, showing previous and current balances.
- **Visualization**: View charts that summarize monthly deposit balances, helping users track the growth or decline of their accounts over time.
- **Dynamic Charts**: Each deposit's history is visualized on a graph that updates in real-time as deposits are modified. The application also supports viewing multiple deposit histories simultaneously.
- **Responsive Dashboard**: The dashboard provides a clear overview of all accounts, displaying the current balance of each deposit and allowing for quick access to history visualization.

## Future Features

- **Currency Conversion Tracking**: Integration with WebAPI to track savings in multiple currencies by fetching real-time currency exchange rates.
- **Precious Metals Integration**: Fetch current prices of precious metals (gold, silver, etc.) through WebAPI and allow users to track their savings in those assets.
- **Enhanced Charting Options**: Additional chart types to improve the visualization of deposit history and account performance over time.
- **Precious Metal Deposits**: The ability to add deposits in precious metals, showing their value trends based on current market data.

## Technologies Used

- **ASP.NET MVC**: For developing the core web application and handling user interactions.
- **Entity Framework (EF Core)**: For managing data models and interactions with the SQLite database.
- **SQLite**: Used as the initial database engine for development and deployment simplicity.
- **Python**: Leveraged for generating financial charts using `pandas` and `plotly` libraries. Charts are dynamically rendered in the application.
- **JavaScript and jQuery**: Enhance user experience by enabling dynamic updates, deposit selection, and chart interaction without reloading the page.
- **Bootstrap**: For styling the user interface, ensuring responsiveness across various device sizes.
- **External APIs**: Planned integration with currency and precious metal price APIs for real-time data tracking and conversion.

## Installation

To set up the project locally, follow these steps:
1. Clone the repository from GitHub.
2. Open the solution in Visual Studio.
3. Restore the NuGet packages.
4. Run the application using the built-in web server.
5. The application will be accessible on `http://localhost:[port]`.

## Running the Python Scripts for Charts
-The application uses Python scripts to generate charts, so ensure you have the following dependencies installed:
```bash
pip install pandas plotly colorama
```
-The Python scripts are executed automatically when the application prepares data for chart generation. All generated charts will be saved to the wwwroot/Graphs directory.

## How It Works
The dashboard displays an overview of all deposits, including their names and current balances. By clicking on any deposit, the user can view a detailed chart that shows the history of the selected deposit, including previous and current balances.
- **Deposit Summary**: The dashboard shows a quick summary of deposit balances.
- **Interactive Graphs**: Selecting a deposit generates a chart for that deposit. Multiple deposit charts can be displayed simultaneously.
- **Total Balance Chart**: The application includes a special deposit that sums all deposit balances, allowing users to track their total financial standing over time.

## Future Enhancements
- **API Integration**: Fetching real-time currency and precious metal rates through WebAPI for enhanced savings tracking in foreign currencies and commodities.
- **Multi-Currency Support**: Automatically convert deposits in foreign currencies into local currency, showing real-time valuations.
- **More Chart Types**: Provide additional visualizations, such as pie charts, bar charts, or more detailed historical trends.
- **Multi-User Authentication**: Implement user profiles with authentication to support multiple users tracking separate finances in the same application.

## Contributing

Contributions are welcome! Please submit a pull request with your changes, and I'll review them as soon as possible.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.
