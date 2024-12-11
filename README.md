# Applied activity 4
## Group members: 
Athul Mathew - A00290168 [profile selection , exception]
Vishnuprabha - A00287475 [login , intial push ]
Himani Himani - A00288620 [ Navigation ]

### WEBAPP choosen for automated testing is Netflix.
Netflix is a subscription based streaming platform where users an watch TV shows and Movies. THey provide a web app and desktop appilication for user conveninence. Netflix use Java and Spring Boot for backend services, Python for data science, React. js and Node. js for frontend development, and AWS for cloud infrastructure.

### Test Cases for Netflix Automation Code
** Functional Test Cases

Test Case ID	Description	Preconditions	Test Steps	Expected Result
**
 TC-FUNC-01	Test login functionality with valid credentials	User has valid Netflix credentials. Chrome browser is installed.	
    1. Launch the program.
    2. Enter valid email and password.
    3. Click "Sign In".	User successfully logs into Netflix, and the profile selection page is displayed.
TC-FUNC-02	Test login functionality with invalid credentials	Chrome browser is installed.	
    1. Launch the program.
    2. Enter invalid email and/or password.
    3. Click "Sign In".	Login fails, and an error message is displayed on the screen.
TC-FUNC-03	Test profile selection functionality after login	User is logged in, and profile selection page is visible.	
    1. Locate the first profile icon.
    2. Click on the profile icon.	User is successfully navigated to the main Netflix dashboard corresponding to the selected profile.

### Usability and Accessibility Test Cases
Test Case ID	Description	Preconditions	Test Steps	Expected Result
TC-USE-01	Test visibility of error messages for invalid credentials	User attempts login with invalid credentials.	1. Launch the program.
2. Enter invalid email and/or password.
3. Click "Sign In".	Error message is displayed clearly and informs the user about incorrect credentials.
TC-USE-02	Test accessibility of profile icons for mouse interaction	User is logged in, and profile selection page is visible.	1. Navigate to the profile selection page.
2. Hover and click on a profile icon.	Profile icons are clickable, and hover effects indicate interactiveness.
TC-USE-03	Test system behavior when no credentials are entered	Chrome browser is installed.	1. Launch the program.
2. Leave email and password fields empty.
3. Click "Sign In".	System displays a message prompting the user to enter both email and password before proceeding.
