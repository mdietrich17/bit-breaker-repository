2019-20 Team Project Inception
=====================================

## Summary of Our Approach to Software Development


## Initial Vision Discussion with Stakeholders

Primary Stakeholder -- Becka, Amazing professor with interest in services for minority populations. 

**Our parents and family members are getting to a point in their life  in which technology is becoming difficult or cumbersome to try to use. The problem is that social sites are populated with people who don't have the same concerns or requirements. They want a place to go for 65+ (only) people that has a simple clean UI that is comprehensive. This should help seniors find people and services that are useful to them in an easy to use enviornment. **

The product is centered around these core features:

1. Create and store user profiles with photos. Information included in the profile will be (atleast):
    a. First Name 
    b. Last Name
    c. Birthday (w/o the year, not DOB due to privacy)
    d. Location 
    e. Hobbies
    f. A profile biography so people know who these people are. 
    g. A Veteran indicator (if applicable)
        a. when and where served
        b. Rank at Discharge 
    h. Phone number for validation. (kept private)
    * The profile in this step will aid the two additional features. 

2. Provide and implement a comprehensive list of services and activities that are taking place in the area that relate to the demographic. This is so seniors are able to find places to congregate and meet poeople. This will also alert them of news in their area, weather and multiple features amongst services. 

3. An easy to use UI that is not cluttered and easy to read and with buttons that are easy to operate. Use an algorithm to match people personally, allow for people to be 'friends' and 'follow' the stories of other people using the platform. 


## Initial Requirements Elaboration and Elicitation

### Questions
1. 
2. 
3. 
4. 
5. 

### Interviews with Stakeholders                                                         
1. 
2. 
3.  
4.   
5. 

## List of Needs and Features 

1. They want a nice looking site, with a clean light modern style, images that envoke inclusion and positivity. 
It should be easy to find the features available for free and then have an obvious link to register for an account or log in.  It should be fast and easily navigable for seniors.  
2. A profile that will be individual for each user. So that users are able to search the database and find others that have similar interests. They would like some type of designation for veterans so that peopole can link up based on service history. Profile must be easy to see and have a profile photo of the person. It should list their 'public' personal information that they used when signing up for the site. Maybe show what the people like or something like that. 
3. Logins will be required for updating profiles and/or leaving comments on other peoples pages, this includes posting photos on the site. 
4. Admin logins are needed for entering new data.  Only employees and contractors will be allowed to enter, edit or delete data.
5. "Standard" logins are fine.  Use email (must be unique) for username and then require an 4 digit pin as password.  Will eventually need to confirm by email to try to prevent some forms of misuse.  Admins and contractors must be manually added by the software Architect. 
6. The core entity is the Senior.  They are essentially free agents in the system.  They can be a member of one or more groups, mailing lists or friends list(s), then change at any time.  Later when we want to do predictive analysis we'll allow seniors to add 'suggested' friends to their pages or items of interest to them. 
7. Advertisments for products that are focused directly to seniors. AARP, LYFT, rideshare or any type of products that are released that may fullfill a need of the demographic in general.                          
8. We want to be able to geo-Refernce: This will mean showing a Google Map or (similar product) of an area or event. This will also include providing directions through the mapping interface for people to reach our event or locations of interest throughout the community for Seniors. 
9. They would like to be able to comment on others users profiles and posts, there should be a way to 'like' stuff and a way to hide types of posts that are of no interest to a person. They do not want adds popping up all the time messing up the user experience. 


## Initial Modeling

### Use Case Diagrams

### Other Modeling

## Identify Non-Functional Requirements

1. User accounts and data must be stored indefinitely. They could have records removed upon qualified reasons. 
2. Passwords should not expire so that the password is easy to remember. 
3. Site should never return debug error pages.  Web server should have a custom 404 page that is cute or funny and has a link to the main index page.
6. English will be the default language.
7. Employees and Admins must use 2 step-authentication.
8. Emails are optional but they can make user name on their own and there would be validation to ensure unique. 

## Identify Functional Requirements (User Stories)

E: Epic  
U: User Story  
T: Task  

1. 
   1. 
   2. 
   3. 
   4.
2. 
   1. 
   2. 
   3. 
   4. 
   5. 
3. 
    1. 
    2. 
    3. 
4.
5. 
6. 
7. 
8. 
7. 
    1. 
    2. 
8. 
    1. 
    2. 
9. 
    1. 
    2. 
10. 
    1. 
    2. 
11. 
12. 

## Initial Architecture Envisioning
[Architecture](Architecture.PNG)

## Agile Data Modeling

## Timeline and Release Plan