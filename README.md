# MyBudget

## Project Overview

MyBudget is a personal finance management application developed in ASP.NET MVC. The application helps users track their monthly income and expenses, manage account balances, and monitor savings, including those in precious metals like gold and silver. It offers a simple and intuitive interface to help users stay on top of their finances.

## Features

- **Income Tracking**: Allows users to input their monthly income and categorize it for better insights.
- **Expense Management**: Provides an interface for users to record their expenses, also categorized for better tracking.
- **Account Management**: Users can add multiple accounts, manage their balances, and view the overall financial status.
- **Savings Visualization**: The application generates charts to show trends in account balances and savings over time.
- **Precious Metals Integration**: Integrates with an external API to fetch the latest prices of precious metals like gold and silver. Users can input the amount of metal they own, and the app will calculate its current value. Historical data is stored to compare trends over time.
- **Data Storage**: Initially, the application uses SQLite as the database engine, but it's designed to be scalable and can be migrated to a database server in the future.

## Technologies Used

- **ASP.NET MVC**: For developing the web application and handling user interactions.
- **Entity Framework**: For managing the application's data models and database interactions.
- **SQLite**: Used as the initial database engine for easy deployment.
- **Python**: Used for generating financial charts through the pandas library. The charts will be rendered in the application to visualize income, expenses, and savings trends.
- **JavaScript and jQuery**: For enhancing user experience with dynamic content updates.
- **External API Integration**: To fetch real-time data on precious metals prices and display their value trends in the application.

## Future Enhancements

- **Database Migration**: Moving from SQLite to a more robust database server as the application scales.
- **Enhanced Reporting**: Adding more detailed financial reports and comparison charts.
- **User Authentication**: Implementing user authentication and profiles to securely manage multiple user accounts.

## Installation

To set up the project locally, follow these steps:

1. Clone the repository from GitHub.
2. Open the solution in Visual Studio.
3. Restore the NuGet packages.
4. Run the application using the built-in web server.
5. The application will be accessible on `http://localhost:[port]`.

## Contributing

Contributions are welcome! Please submit a pull request with your changes, and I'll review them as soon as possible.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.
