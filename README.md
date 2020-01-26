# VProductComparison
This repository is for tarrif comparison for different products 

Description of solution Items : 
1. TariffComparison
This is the main Rest based API build on .Net Core platform, which will be exposed for clients to be consumed. 

2. TariffComparison.Services
This project is a class library to support Tarrif comparison API. All the logic and model building lives here.

3. TarrifComparison.Models
This is another class library where all models is defined based on requirements.

4. TarrifComparison.Tests
This project is Build using Xunit framwork for unit testing to support TDD. For now there is only two basic test scenarios present in there one for negative numbers in consumtion unit and another for correct value.

5. TarrifComparison.AngularClient
This is a single page application build using latest stable angular version. It consist two routes Home and Product compare which will take consumed unit as input and return the tarrifs based on that. 

6. Alexa Skill 
I have created a skill to be used on alexa device using azure logic app as a backend for skill. This skill can be invoked with the phrase "Alexa, start Verivox Compare”.

A model to build two products and compare tarrif based on thier annual charges. Comparison will accept input paramter consumption kwh/year.

Response will return a List of tarrif for both product based on annual cost in acscending order.

Swagger Documentation: Documentation can be accessed using relative Url "/Swagger/UI"
I have also attached two images of swagger below 

<img src="https://drive.google.com/open?id=1CMdrQ-3hQthupVUxNm72j3ICU7YYzxfP"/>

<img src="https://drive.google.com/open?id=1E_wvJiWMitsN5Pg7uDrNgYLXHGzGBFXN"/>
