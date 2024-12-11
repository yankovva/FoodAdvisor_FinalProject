# 🍴 FoodAdvisor 🍴

Welcome to **FoodAdvisor**, your ultimate culinary companion! 🌟 This web application is designed to help users discover, explore, and share the best dining experiences and recipes. 🥗🍔🍰

---

## ✨ Features

- **📍 Restaurant Directory**: Browse and discover restaurants by categories such as bistros, cafes, bakeries, fine dining, and more. Each restaurant listing provides detailed information, including location, price range, and user reviews.

- **📖 Recipe Sharing**: Create, edit, and explore recipes shared by other food enthusiasts. Users can add ingredients, cooking instructions, and upload images for their recipes.

- **🔐 User Roles and Authentication**: Secure login and registration system with roles like Admin and Regular User to ensure the appropriate access level.

- **💾 Favorites Management**: Save your favorite restaurants and recipes for quick access later. Users can also manage and categorize their saved items.

- **🔍 Search and Filter Options**: Use advanced search and filtering tools to find restaurants or recipes based on specific preferences, such as cuisine type, preparation time, or dietary restrictions.

- **📢 Notifications**: Get real-time updates and alerts, such as successful operations or errors, using a sleek notification system powered by Toastr.js.

---

## 🛠️ Technologies Used

- **Backend**:
  - ASP.NET Core for robust and scalable web application architecture.
  - Entity Framework Core for efficient data management and querying.

- **Frontend**:
  - HTML5, CSS3, JavaScript for a modern and responsive user interface.
  - Razor Pages for dynamic content rendering.
  - **Bootstrap** for styling components and layouts (not used across the entire application).

- **Database**:
  - SQL Server for reliable and secure data storage.

- **Other Tools**:
  - Toastr.js for elegant notifications.
  - Anti-Forgery Tokens for enhanced security against CSRF attacks.

---

## 🚀 Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/FoodAdvisor.git
   ```

2. Navigate to the project directory:
   ```bash
   cd FoodAdvisor
   ```

3. Set up the database:
   - Update the connection string in `appsettings.json`.
   - Run the migrations:
     ```bash
     dotnet ef database update
     ```

4. Build and run the application:
   ```bash
   dotnet run
   ```

---

## 🧑‍🍳 Usage

- **Admin Features**:
  - Add, update, and delete restaurants and recipes.
  - Manage user roles and permissions.

- **User Features**:
  - Register and log in to access personalized features.
  - Browse the restaurant directory or recipe collection.
  - Add recipes with images and detailed instructions.
  - Save favorites and share your experiences.

- **Search and Filter**:
  - Search for restaurants by name, location, or category.
  - Filter recipes based on preparation time, ingredients, or cuisine.

---

## 🤝 Contributing

We welcome contributions! Here's how you can help:

1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes:
   ```bash
   git commit -m "Add feature description"
   ```
4. Push to your branch:
   ```bash
   git push origin feature-name
   ```
5. Open a pull request and describe your changes.

---

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

Enjoy using **FoodAdvisor** and discovering amazing culinary experiences! 🥂
