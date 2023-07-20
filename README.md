# SproutDotNetExam

Question:

If we are going to deploy this on production, what do you think is the next
improvement that you will prioritize next? This can be a feature, a tech debt, or
an architectural design.

Answer:

If we are going to deploy this on production, the next
improvement that I will be prioritize next would be :

- Making it a Micro Services instead of using MVC or Monolithic Design. with this we can develop applications for other platforms without re-coding the backend
- Creating a nugget package for the domain entities
- I would create a reporting page
- Better season handling and token expiry
- Make Salaries and Employee Types persistent in the database to make it dynamic and flexible
- Create an SP for computing so that if ever we were to add a new Employee Types or edit computations we won't need to rebuild the whole applications and can deploy to production without down times and for better performance
- I would upgrade the UI to Blazor instead of JS Frameworks for better support
- I would update the the nuget packages and other references to the latest release for security purposes and support
- To add more features related to HRIS e.g Timesheet management and clocking, payslip generator, leave filling,  etc.
