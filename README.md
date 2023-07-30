# TheoPalmFit
User story
------------------------------
------------------------------
------------------------------
Palmfit
------------------------
-----------------------------------
Overview
---------
Short Description
-
Palmfit is an easy-to-use calorie calculator that helps users measure their calorie intake in order to make better healthy food intake decisions. 

Platform
------
Web Application

Theme
----------
The objective of this product is to help customers/users keep track of their daily calorie consumption so as to stay healthy.

Problem 
-------------
A good number of Nigerians passively read through the nutritional value and content of packaged foods leaving them with little information about what the nutritional value and calorie count is in such packaged foods and as such do not know their calorie consumption.

Solution
------------
Health practitioners advise that a woman should consume an average of 1,600 to 2,000 calories and 2,000 to 3,000 calories for men Source.
Palmfit is designed to help users make the best health decisions by calculating the amount of calories they need to take on a daily basis. Other features include suggesting meal plans to users while considering their present health conditions and fitness goals.

Proposed State
User flow chart of proposed state
Goals & Success
Goal
Pointers
Metric 

Customer Acquisition
-
This is measured by the number of app downloads, site visitors and the number of accounts created.


Number of users who visit the site
Number of users who download the web app

Customer Activation
-
This is measured by the number of user accounts created.
Number of successfully registered users.
Number of users that calculated their food calories on the app.
Number of users who have made payment on the app. 

Customer Retention
-
This is measured by the number of users who repeatedly calculate their calories on Palmfit.
Number of users who have calculated their calories on the app more than twice.
Number of users who have made more than two payments or two consecutive payments.

Customer Revenue
-
This is measured by the number of users that subscribe monthly to the platform
Number of users that pay N200 at the end of every week.

Customer Referral
-
A referral link on the web app
Number of referral links shared by users.

Customer feedback
-
A like and dislike button emoji  as an affirmation of customer satisfaction
Number of likes and dislikes emoji clicked.

Constraints
-
Securing adequate funding
Gathering enough specific data on the various meals and food classes.

Potential Risks
-
Strict compliance regulations 

Requirements & User Stories

Requirement Number:
User Story:
Priority Level:
Acceptance Criteria

1.
Landing Page
As a visitor, I want to be able to get all the information about Palmfit’s services and should be able to calculate my calories on a first time interaction when I visit the web app
level: Critical 
Given I'm a visitor, when I input the App’s URL on my search engine, I should see a landing page with information about the services the app renders and calculate my food calories.

2.
User Onboarding
Sign up
Sign in
As a user, I want to be able to sign up on Palmfit so that I can create an account.
level: Critical 
Given I'm a guest user, when I input my email and password on the sign up page, the app would send an OTP verification code to my email to verify my account.

3.
User dashboard and referral review
As a user, I want to have a profile dashboard where I can access my user details on the app and refer app if satisfied with the service
Critical 
Given I’m a registered user, when I click on the profile icon, I should see my profile dashboard with my details on it and a referral link.

4.
A calorie counting dashboard.
As a user, I want to be able to input my preferred food choice on the app. 
Critical 
Given I’m a registered user, when I input my food choice the app will  calculate and show the amount of calories contained in the food

5.
A food register dashboard
-with a daily and weekly food plan
As a user, I want to be able to select preferred food choices from the recommended food classes on my profile.
Critical 
Given I'm a user, when I click on the food suggestion button, I should see daily and weekly food plans of food classes with the calories they contain.

6.
Personal user meal diary with a calendar
As a user, I want to be able to plan a calorie check with a personal diary to observe my food consumption.
Critical 
Given I'm a user, when I look up my user dashboard, I should see a calendar and custom diary where I can schedule the calories I intend to consume for a personal time duration.
 
7.
Progress bar and meal history
As a user, I want to be able to see the calories I've taken in a day or week and the amount of calories needed to reach the calorie cap for the day. Also, I want to see the history of my calorie consumption for previous days.
Critical 
Given I'm a user, when I click on my calorie history, I should see the calories consumed already and the calories left to reach my daily calorie max.

8.
Payment plan
As a user, I want to have a direct billing on my bank account so I can make payment for Palmfit subscription on a monthly basis.
Critical
Given I’m a user, after inputting my card details, I want to have money deducted directly from my account every month.

9.
A customer feedback pop-up
As a user, I want to be able to give feedback to my satisfaction.
Critical
Given I'm a user, after carrying out some series of tasks, when I give my star rating, I should get a confirmation pop up

10. 
Mobile wallet
As a user, I want to be able to reserve money in my wallet and make payment subscriptions from the wallet as an alternative to a direct billing on my bank account.
Nice to have 
Given I’m a user, when my subscription is over, I should get an automatic debit from my mobile wallet. 


------------------------------
-------------------------------
--------------------------------
------------------------------
 


USER ONBOARDING PROCESSES
------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------
Sign Up
---------
As a user, I want to be able to sign up on Palmfit so that I can create an account.

Login
--------
As a registered user of the platform,
I want a secure and efficient way to sign in to my account,
So that I can access my personalized content and perform various actions on the platform.

Send Otp to user's Email
--------------------------
As a user attempting to access secure features or perform sensitive actions on the platform,
I want to receive a one-time password (OTP) on my registered email address,
So that I can verify my identity and ensure a secure authentication process.

Validate Otp
------------------------
As a user attempting to access secure features or perform sensitive actions on the platform,
I want a reliable method to validate the one-time password (OTP) received in my email,
So that I can verify my identity and ensure a secure authentication process.

PassWord Reset
----------------------
As a user who has forgotten my password or wants to reset it,
I want a secure and straightforward method to reset my password,
So that I can regain access to my account and ensure the security of my account information.

Sign Out
------------------------
As a logged-in user of the platform,
I want a convenient and secure way to sign out of my account,
So that I can terminate my session and ensure the protection of my account and sensitive information.


FOOD MANAGEMENT 
-----------------------------------------
----------------------------------------

Search for food
-----------------
As a user who wants to find specific foods based on categories or food names, I want a Food Search API that allows me to search for foods efficiently, So that I can access their nutritional information and make informed dietary choices.

Add food
---------------
As a platform administrator or authorised user with appropriate permissions, I want an API that allows me to add new foods and their nutritional information to the database, So that users can access accurate nutritional data for the newly added foods.

Update food
-----------------
As a platform administrator or authorized user with appropriate permissions, I want an API that allows me to update foods and their nutritional information to the database, So that users can access accurate nutritional data for the updated foods.

Get all meals
---------------------
As a user who wants to view a list of all my meals, I want an API that allows me to retrieve and access information about all the meals associated with my account, So that I can review my dietary choices, track my meal history, and make better nutritional decisions.

Get a specific meal 
---------------------
As a user who wants to access information about a specific meal, I want an API that allows me to retrieve the details of a meal, So that I can view its nutritional information and understand its components

Add food to daily/weekly plan
-------------------------------
As a user who wants to plan my daily or weekly meals, I want an API that allows me to add specific foods to my daily or weekly meal plan, So that I can organise my meals, track my nutritional intake, and maintain a balanced diet.

Delete food
---------------
As a platform administrator or authorised user with appropriate permissions, I want an API that allows me to delete foods and their nutritional information from the database, So that outdated or incorrect foods can be removed, ensuring the accuracy of the available food data.

Create class of food
-----------------------------
As a platform administrator or authorised user with appropriate permissions, I want an API that allows me to create a new class of food and associate related food items to it, So that I can organise foods into meaningful categories for better nutritional analysis and user experience

Filter food based on category or class
---------------------------------------
As a user who wants to find specific foods based on their categories or classes, I want an API that allows me to filter foods efficiently, So that I can easily access relevant foods based on my dietary preferences or nutritional requirements.

Update class of food
--------------------------
As a platform administrator or authorised user with appropriate permissions, I want an API that allows me to update the details of a food class, So that I can keep the classification of food items accurate and relevant for nutritional analysis and user experience.

Delete class of food
-------------------------
As a platform administrator or authorised user with appropriate permissions, I want an API that allows me to delete a food class and its associated food items, So that I can keep the food classification system up-to-date and remove obsolete or irrelevant categories.


OTHER ACTIVITIES/EVENTS
---------------------
---------------------

Role Management
----------------
As a platform administrator or developer,
I want a flexible and easy-to-use Roles Management API,
So that I can define, assign, and manage user roles and permissions effectively within the system.

Calculate Calories
-----------------------
As a user who wants to maintain a healthy diet and track my calorie intake,
I want an API that can accurately calculate the number of calories in various foods and meals,
So that I can make informed dietary choices and monitor my daily caloric consumption.

Retrieve daily/weekly meal plan
----------------------------------
As a health-conscious user, I want access to an API that can provide me with personalized daily and weekly meal plans, so that I can easily follow a balanced and nutritious diet according to my preferences and dietary requirements.
