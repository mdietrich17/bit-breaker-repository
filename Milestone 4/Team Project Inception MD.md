==========================================================================
Team Project Inception
==========================================================================
Summary of Our Approach to Software Development
=====================================
Our approach to software development is utilizing Agile Development techniques. This will include following best practices provided throughout the SCRUM handbook. We focus primarily on DAD methodologies and utilize a hybrid mix between the aforementioned to maximize our team efficiency.
=====================================
Initial Vision Discussion with Stakeholders
=====================================
Primary Stakeholder – Dr. Morgan, Amazing professor with an interest in services for minority populations. 
Our family members are getting to a point in their life in which technology is becoming difficult or cumbersome to try to use. The problem is that social sites are populated with people who don't have the same concerns or requirements. They want a place to go for 65+ (only) people that has a simple clean UI that is comprehensive. This should help seniors find people and services that are useful to them in an easy to use environment. The goal is to be a place that seniors would want to communicate without all the background noise that consistently populates other social media platforms.  
=====================================
Vision statement
=====================================
Our vision is to build a web application for seniors (those who are 65+) who need a convenient, easy way to socialize and find activities, the Simply Seniors website is an information system that will provide a single, convenient point of access for seniors to find people and services near them. This includes information about events close to their proximity that may interest them, ways to group up with others with similar interests to join those events, and a convenient, easy to read, use, and navigate platform for seniors. Unlike other social media sites, our product will be very easy to use for seniors with a simple, generic, and convenient layout, as well as have seniors be able to find activities of interest near them, and be able to pair up with others with similar interests. 
=====================================
The product is centered around these core features:
=====================================
1. Create and store user profiles with photos. Information included in the profile will be (at least):
    a. First Name (String)
    b. Last Name (String)
    c. Birthday (w/o the year, not DOB due to privacy) (dateTime)
    d. Location (String)
    e. Hobbies (String[])
    f. A profile biography so people know who these people are. (NVARCHAR(500))
If we want a restriction on the size of biographies...
    g. A Veteran indicator (if applicable to user)
        a. When and where served
        b. Rank at Discharge 
    h. Phone number for validation. (kept private)
We intent to allow users to search for other users within our network. They will be able to add friends, post and/or share things (their own posts or other user posts), add comments (on their own posts, other user posts, or group posts), chat with each other, and interact with each other in different ways. The site will allow users to search based on certain filters, such as the inclusion of a search feature to find people based on their general location or personal factors in which they have in common. Since some user data will be online (as they will put their profile info, posts, etc online), we will ensure privacy and security settings are easy to manage and change, and will either have the default for posts and profile information to be set to friends only, or have them choose during registration process. We should also strive to be transparent in how information is used but in an easy to understand format. 

2. Simply Seniors will provide a comprehensive list of services and implement a methodology to display activities that are taking place in the area that relate to the user. This is so users are able to find places to congregate, meet people, and just use the features within the site. It will also alert users of news in their area, weather and multiple features amongst services. 
(veterans can only see vets events for example, give them tailored feedback on features) 
List of potential API’S for proposed features
(Google Maps API will give us places that are around a particular person) 
https://developers.google.com/maps/documentation/?_ga=2.92412509.1359033826.1580536876-1750554004.1580536876&_gac=1.158300360.1580536915.Cj0KCQiAvc_xBRCYARIsAC5QT9m8E1q9opYtc1ygiRnFS3xleV4ltDtYgN73uL9FKRiLgD3EZ5AQ4eoaAlv_EALw_wcB
(TextToSpeech API for reading text aloud )
https://cloud.google.com/text-to-speech/docs
(Weather App to display their local weather)
https://www.weatherapi.com/docs/
(Events API for location-based data)
https://www.predicthq.com/events/location-based-data
(possibly AI for potential chat bot to assist with accessibility functions)
 https://www.ibm.com/watson/services/text-to-speech/) 

 3. An easy to use, minimalistic UI design that is not cluttered and easy to read and with buttons that are easy to operate, as well as a simple, easy navigational structure. Larger buttons, font/text than typical user interfaces will be used for our web app (preferably min of 16px text would be good, possibly sans serif typefaces as it it easy readability). Color contrast is important as well in UI design, as shades of blue can appear fade as a human ages so color contrast should be increased for our website to compensate for this possibility. (source:https://www.toptal.com/designers/ui/ui-design-for-older-adults). 
Icons should be labeled with text whenever possible. A help page that will allow someone to learn how to navigate the site and answer basic questions, and this help page will be easy to get to at any time. This may include videos, links to tutorials, or FAQ. Possibly have a help feature/tutorial when users first register to get them familiar with the website to increase their probability of continuous interaction with the website. 

4. Use an algorithm to match people personally. This will most likely be based on military service and/or hobbies that the user inputs either at creation of the account or later on. Simply Seniors will allow for people to be 'friends' and 'follow' the stories of other people using the platform. Would recommend people with shared interests (such as hobbies like book clubs, calligraphy, creative writing/poetry, knitting, dancing, crocheting, chess, etc), nearby (in their city, retirement center, etc) and/or mutual friends. This would allow them to make comments to each other and also make comments on people's comments. This would include the integration of a ‘like’ type system in which the user can rate a message, event or interaction. 
____________________________________________________________________________
=====================================
Additional features for project if time permits
=====================================
4.  Provide an entertainment center to users in the form of possibly: games, news, and non-copyrighted movies/music, and with those videos, subtitles could be provided. 

5. Provide mobile support for multiple smart devices such as iPhone, Android, Windows phone, and other mobile devices. This would include creation of an API with core features that we could launch to Azure that we could then utilize Android or OIS to make phone applications that consume the API. This will need to be fully realized with significant research into many things.
Version 2: We could just utilize Bootstrap V4 to build a super responsive site with alot of containers that would allow it to be used on chrome or safari within a phone’s environment. This would significantly reduce the work involved, however will not be nearly as mobile. 

6. Make a user group system so that users can create their own group pages to organize their own events or discussions. There could be veterans group, or a group for selling stuff, or linked directly to residency living environments. 
==========================================================================
  Initial Requirements Elaboration and Elicitation
==========================================================================  
 Questions/Interview Feedback 
=====================================
1. How much would this service cost? If free, would it be permanently free or would there be any subscription charges? How about ads? 
    Answer: We would like this website to be free, but have non-intrusive ads that do not impact the user experience. DC
2. Will this be set up cross-platform so it is accessible on tablets or phones, or just computers?
    Answer: We would like it to eventually work for phones like in a web browser. Maybe in the future we would hire someone to make it a phone app. 
3. Will there be a database, and what all would be in the database (database for users, obviously, but anything else or anything specific here)?
	Answer: User data such as email, optional -- see ER diagram for more info on DBs.
4. For users searching on the website for finding other users with similar interests, does it search things based on common “likes” like how Facebook allows you to like pages, or does it search keywords based on status posts?
	Answer: Users with the same interests will be matched based on similar likes. 
5. Is there a separate tab for searching for users (specific names) vs searching for people with common interests (based on keywords)?
    Answer: Users will be searched based on their profile name.
6. For these pages that you can “like” are you allowed to like them during the registration process or something you do afterwards, and do you just search for them or should suggested ones continuously pop up for users to like (or both)?
    Answer: During the registration process, you can select hobbies that you like, and will be able to easily change/edit/delete/add hobbies later as well. Maybe we will integrate a feature to pop up suggested likes later on, but for right now, our main priority is to allow users to, as they register, select hobbies, and edit/add later on as well.
7. Will users be able to post statuses, pictures, and reshare posts, or just comment on the discussion groups that they are registered with/joined?
    Answer: Yes, users will be able to post statuses, pictures, and reshare posts.
8. How many different features for posting do the users have? Can they post pictures, videos, links, etc, anything else?
    Answer: They can post pictures, videos, and links. 
9. Is all of the information on user’s profiles public or private by default? Can this be changed? 
    Answer: Not all information will be private, but things such as: Mailing address and phone number will initially be private, but can be made public if the user desires. 
10. What are some of the features that the user base wants, and how do we find out what they want (Google, interviewing elders, etc)? 
    Answer: meeting forums, chat rooms, news, and events near them. Interviewing the elderly in the form of physical interviews and surveys, as well as researching what they would like.
11. Is this platform for those in retirement centers or just anyone 65+?
    Answer: Anyone at/over the age of 65+
12. Is it required for the users to be 65+ or is it just recommended? Is there a way to ensure this is accurate? 
    Answer: It is required to be 55 or older for this web app, but 65+ is the recommended age for this website, and we will assume our clients aren’t lying about their age (much like most websites don’t really have a certain way of verifying, like how Facebook anyone can lie about their age).
13. Would there be a way to search for people who are in retirement centers, to search for people in the same retirement center to meet up with them?
    Answer: Yes, there will be a search feature to find people based on their retirement center.
14. How many ads per page will there be, and will there be ads on every page?
    Answer: The service will be free at first and once a user base has been established non-intrusive ads will be listed on website services. 
15. If emails are optional, is there a different way to get back into your account if you get locked out, like security questions? 
    Answer: Users can receive a text message with a code that will allow them to reclaim their account and reset their password. 
==========================================================================
List of Needs and Features
==========================================================================
 1. They want a nice-looking site, with a clean light modern style, images that evoke inclusion and positivity. It should be easy to find the features available for free and then have an obvious link to register for an account or log in.  It should be fast and easily navigable for seniors and/or people with disabilities. It would be nice to be able to zoom or change the size of things on the screen and have limited customization options so that it is easy to use and learn. We will use bright colors and use imagery that promotes a positive healthy lifestyle.    
2. A profile that will be individual for each user. So that users are able to search the database and find others that have similar interests. They would like some type of designation for veterans so that people can link up based on service history. Profile must be easy to see and have a profile photo of the person. It should list their 'public' personal information that they used when signing up for the site. Maybe show what the people like or something like that. 
3. Logins will be required for updating profiles and/or leaving comments on other people’s pages, this includes posting photos on the site. By having logins, we hope to eliminate all robotic attacks and also do some validation of our users. This site is advertised to 65+ year old adults and we want to at least do basic authentication and require them to state they fit the criteria to register. There will be a help page that will assist our users in registering and explaining why they need to and what they get for doing so. We will utilize an email or notification needed to verify that they are a real person and this will allow us to record the email address of the initial user for our records. There will be two types of logins: users, admin. The admin will be the super user for the site and will have full authorities, whereas, users will have limited access to features that only pertain to them. 
4. Admin logins are REQUIRED for entering new data and/or modifying existing data stores.  Only employees and contractors will be allowed to enter, edit or delete data. This will allow protection for our users and effective management techniques of our backend databases. 
 These admin ‘super users’ will be restricted to individual approval from the development team prior to any system access. 
5. "Standard" logins are fine.  Use of a validated email (must be unique) will be use username and then require a 4 digit pin as password.  Will eventually need to confirm by email to try to prevent some forms of misuse.  Admins and contractors must be manually added by the software Architect within the development team. See requirement 4 for more information.
	** Validated email refers to an email or SMS message that is sent to the user at account registration phase to verify that they truly want to use the service and are not bots. Validated implies the notification method was confirmed. 
6. The core entity is the Senior.  They are essentially free agents in the system.  They can be a member of one or more groups, mailing lists or friends list(s), then change at any time.  Later when we want to do predictive analysis, we'll allow seniors to add 'suggested' friends to their pages or items of interest to them. 
7. Advertisements for products that are focused directly to seniors. AARP, LYFT, rideshare or any type of products that are released that may fulfill a need of the demographic in general.                          
8. We want to be able to geo-Reference: This will mean showing a Google Map or (similar product) of an area or event. This will also include providing directions through the mapping interface for people to reach our event or locations of interest throughout the community for Seniors. 
9. They would like to be able to comment on other users’ profiles and posts, there should be a way to 'like' stuff and a way to hide types of posts that are of no interest to a person. They do not want adds popping up all the time messing up the user experience. 
=====================================
Initial Architecture Envisioning
[Architecture](architecture.PNG)
=====================================
Use Case Diagram(s)
[Use Case Diagram](UseCase.PNG)
=====================================
Use case diagram was drawn up to represent the workflow throughout our system, which would be initiated by the user, this shows how entities may interact with each other. The initial instance begins with an event that has n 
=====================================
UI Diagram
[UI Diagram](UI_diagram.JPG)
==========================================================================
Identify Non-Functional Requirements
==========================================================================
1. User accounts and data must be stored indefinitely. They could have records removed upon qualified reasons. 
2. Passwords should not expire so that the password is easy to remember.
3. Site should never return debug error pages.  Web server should have a custom 404 page that is cute or funny and has a link to the main index page.
4. User must agree that they are over 55 years of age in order to register for an account. 
5. Removal and flagging process in place to remove those that are not qualified to have an account, realized after the fact. 
6. English will be the default language.
7. Employees and Admins must use 2 factor-authentication.
8. Emails are optional but they can make user name on their own and there would be validation to ensure unique. 

==========================================================================
Identify Functional Requirements (User Stories)
E: Epic					  U: User Story 				 T: Task  
==========================================================================
LOG-IN / AUTHENTICATION USER STORIES BELOW
=====================================
E - As a user, I want to be able to join this website, be able to sign back in later, and create a validated account so that I can access all the features of the site. 
	U - As a user, I would like to be able to sign up using my email so that my user name can be used later after registration (ease of access) 
		    Description - We will start an initial ASP.NET MVC5 project with individual user accounts enabled, disable code first migrations, and build a homepage with title and boilerplate items that is clean and simple. We want an initial nice looking, but essentially blank, homepage. The login, etc. parts of it won't work until we have the database built, so we will auto-generate the database here and (in another user story, below) have the up and down scripts be built for everyone to use. For this user story, we will test that the registration works by registering, logging out, and logging back in. 
	U - As a user, I would like to have my information stored in the site’s database so that I can easily register, log out, and log back into my account so that I can log back in and see my information whenever I want to.
	    Description - Create an up script, down script, and seed data into the database so we have data we can start our project with (such as fake users with fake account information) so that we can have multiple “users” to interact and test our features with. Build the database up script to use the Identity tables. Understand it and test that it works: can create an account, log in, out, etc. Remove boilerplate from identity built pages that isn't used. (There is a link to a helper document placed in Moodle for week 3).
	U - As a user, I would like to be able to use a 4-digit pin or something easy to recall for my password so that I can easily use my credentials.
		Description - We will research exactly how to change the default template for passwords, and then will go about changing that. Change the requirement for password in Visual Studios to be max 4 digits, and only numbers (no letters). We will ask them to verify when creating this so we can ensure they entered their numbers correctly. We will also have them be able to change this later in their account settings at any time (after registered). We will test this by logging out and back in after registration to test and see if this works. Potentially provide a password generator of some sort to streamline it for them, if we limit private data collected then our security process will not be as stringent. 
	U - As a new user, I would like to receive an email or notification to validate or confirm my registration so that I know my account is actually working. 
		Description - This would be a type of two step validation so that when a new account is created the user would have to validate that account in order to be able to actually use the site and then eventually build their profiles and interact with the functions therein. We potentially could just use a text message or maybe some other type of quick validation as sometimes emails can be difficult to access and/or take time for the user to go and be able to validation. We don’t want to add a layer of difficulty that would contradict our vision statement for this project. 
=====================================
PROFILES USER STORIES BELOW
=====================================
E - As a user I want to be able to create a user profile so that others will know my interests and/or hobbies and who I am. 
	U - As a user, I would like to be able to create a profile, and be able to edit that profile later so that others can learn about me.
        Description - Have a button or link that says “edit profile” (or similar) after initially registering a user account, this can be clicked at any time and allows users to edit their profile information. This will take the user to an edit page, where the user can edit information such as: first name, last name, birthday, profile picture, location, hobbies, profile biography/about me, veteran indicator (such as info on when and where server and rank at discharge), and a phone number for validation (kept private). This profile will be 
	U - As a user, I would like to be asked about what hobbies interest me upon the registration process, and be able to edit, delete, or add new hobbies later on, so that I can have my hobbies displayed on my profile for my friends (or the public) to see.
	    Description - Have a dropdown, select/radio buttons list, or search feature that allows users to select or search for hobbies that may interest them (such as book clubs, calligraphy, creative writing/poetry, knitting, dancing, crocheting, chess, etc). This will be saved in the database, and users can add hobbies later by searching for them, or delete hobbies that no longer interest them. The users can also view other user’s hobbies when going to their profiles. By default, this information is public (?) so anyone can see anyone’s hobbies.
	U- As a user, I would like to be able to decide my level of privacy regarding my interests/hobbies so that I can possibly restrict users access to my public information.
	    Description - This should have different preset level of privacy such as friends only, everyone and private for either the whole profile or specific items. Some users may want to hide their hobbies from non-friends and allow only people they know to see their information. Each item or category of item may have a privacy setting when the user goes to edit or set-up their profile information.

E - As a user, I would like to be able to display my profile picture, personal (public) information, and have all of my posts in one convenient location so that people can see what I look like and my interests.
	U - As a user, I would like to be able to upload and change my profile picture so that others can identify me.
	    Description- This will allow for an image to be uploaded to our site. This will include modifying database to hold the profile photos as well as integrating the picture into the profile page for the particular user. This may be a 2+ point user story due to the vertical slice that this user story will cut through. Initially, we will have basic functionality without filters or special effects, but that can be added at a later date. Format(s) TBD.
	U - As a user, I would like to be able to display personal information about me, such as a bio (about me) that I can edit at any time, so that I can allow others to learn about me.
	    Description- This will involve creating my ‘personal’ profile that will list the information about myself and my hobbies. This should look clean and be easily readable without crazy colors that contrast to heavily. A profile should list the public information that is available on a particular user. Things such as: name, school they graduated from, veteran status (if applicable), hobbies and any biography information that they have included. The user should be able to opt out of providing public information in additional user story. 
U - As a user, I would like to be able to have a way to identify as a veteran on my profile and put in my veteran information so others can find me based on my identification. 
	    Description- This feature would be so that veterans could be distinguished from other members. This wouldn’t be something too grand as to put off other users, but it would allow to represent their division/unit. Initially we will use the same symbol for all veterans, however in the future we may want a feature that makes them unique to the battles that they served in. 

E- As a user who is a veteran, I would like to be connected to other veterans so that I can connect with old friends and people with a military background. 
	U - As a user, I would like to search for other veterans so that I may build new connections. 
	    Description- This feature will be implementing a filter on an existing search feature or building a brand new custom ‘veterans search bar’ and only have it available to veterans and be styled appropriately. They will be able to find other veterans and then will be presented with options on how to proceed with their communication. This could be a message, or a friend request or maybe a thumbs up that leaves a tag behind. The search should only return people with veteran indicators. 
	U - As a user who is a veteran I would like to have access to services related to military service so that I can get help for PTSD or other conditions
	    Description - This would be a list of services available only to veterans that would include help for PTSD or list to VA’s in the area. It could contain places with discounts only for veterans and/or recommend veteran “safe” locations (no loud bangs, other triggers). This could also include groups that meet for Veterans. 

E - As a user, I would like to be able to choose who can view my profile information (such as my pictures, posts, bio, etc) and allow either only my friends to view my posts or allow them to be open to the public so that I have control over my privacy settings.
    U - As a user, I would like to be able to block other people’s profiles so they can not bother me or send me any further messages. 
        Description -	This feature is essentially privacy protection for the user. This would allow anyone to block another individual within the community. This would be done to stop harassment or any other negative things that are happening to someone on the site. This would be private and the other person being blocked would not be notified or have any way to be able to know that they had been removed. 
    U - As a user, I want to be able to choose my friends and not have someone know that I declined them as a friend. 
        Description - We would incorporate a dialog box that outlined the privacy policy and that the other user would not be notified of the rejection. This will block their account but it will still allow them to see the user in searches so that they don’t realize that the user had purposely denied the request. 
    U - As a user, I want to have a centralized location to go to see all my pending requests so that I can easily approve or deny friend requests. 
        Description - This would involve creating a ‘requests’ page that would allow a user to see all of their pending requests. They would be able to accept or deny the requests at this point and those should go away. We plan to not involve much reporting techniques so that they can see past requests and things because usually that clutters up the site and is useless for our particular demographic. 

E - As an admin (employee or contractor), I want to be able to enter, edit, and delete data if necessary so that I can take down a profile 
	U - As an admin, I want to be able to have ‘super’ user access to the entire site so that I may act as the site’s administrator. 
	    Description- When creating the database have a bit within the users table that signifies if that individual is a “super user”. If the bit is true, then that particular user will be able to have full access to the websites features, editing and deleting of profiles, as well as authorizing other users to become administrators. 
	U - As an admin, I want to enable 2-factor authentication so that we can ensure a safe login process and website overall for all users. 
        Description- Use a google api that takes the admins listed phone number and sends a text code message when they attempt to log into the site. This code will be required it be put into a text in addition their username and password in order for them to access their account. This code will have a grace time of 5 minutes to prevent possible misuse. 
	U - As an admin, I want to require captcha logins in an effort to safeguard our site and our users to ensure that we do not allow robots to register or spam our website.
        Description- Generate a simple captcha that is very user friendly while providing a decent amount of security for the individual. This captcha will be located upon the registration page, so when a user attempts to register to use the website they will have to fulfill the conditions of the captcha in addition to the standard parameters listed (Email, username, password, etc). If the user does not fulfill the requirements of captcha they will be prevented from making an account. If they fail 4 or more times, they will be prevented from using the website (5 minute cooldown).
=====================================
EASE OF ACCESS USER STORIES BELOW
=====================================
E - As a user, I want to be able to see a nice-looking site, with a clean light modern style, images that evoke inclusion and positivity. I would like to be able to see a simple webpage that doesn’t have too many options to choose from (not too complicated), is easy to navigate, and every page is simple to understand (maybe big text) so that I can easily maneuver the website and enjoy my experience.
	U - As a user, I would like to see all of the same (simple and minimalistic) template/design consistent on every page, with large navigation buttons and at least ~16px text, preferably sans serif typefaces and color contrast (as shades of blue are hard to distinguish) so that I can easily navigate and view the homepage and how to get to other pages.
	    Description- This user story relates to keeping our design minimalistic and easy to use. We will use fonts that are larger than normal but not ridiculous so that they output is easy to read for our users. (potentially a magnifying feature in the future). Our hope is to allow for easy navigation throughout the site due to consistent web form styles and essentially consistency throughout the site as a whole. We will do this by using the same format and colors regardless of a log-in or registration page. This will also translate over to forms that are absorbed 
	U - As a user, I would like to see images on links/navigation properties with clear, labeled text under them so that I can easily see where a link will take me. (Example image below)
        Description- This would be related to our ease of access goals. We want to have buttons of a size that are easy to read and write in a font that is also easy on the eyes. The functionality will be simple with easy to decipher errors, colors will be bright and bold as to evoke a feeling of happiness and fun in the end user. 
	U - As a user, I would like to be able to see a custom 404 page that is cute or funny and has a link to the main index page.
        Description- This feature would be so that if they search for another person’s profile after logging into our portal then they will be redirected to a custom 404 page. This could be a motivational quote that we integrate from a quote API, or could simply be a nice picture with instructions on how to get back and try again. One of our Vision’s prerogatives was to enable a site with ease of use as a primary goal. 
	U - As a user, I would like to see a help page that will allow me to learn how to navigate the site and answer my basic questions on the sites core features and functions, and this help page will be easy to return to at any time (preferably at the top of page or somewhere I can easily find it) so that I can never be confused on features/functions of the website.
	    Description- Help pages should be very clear on what they cover as well as the tutorials within. Everything should be short, simple, and easy to understand without losing too many details on how to work the website. A big list of tutorials may be confusing or frustrating to search for some users so it may be better to have a search function or to have a page for categories that then go to more specific ideas. Some tutorials or help pages may be featured so that commonly accessed ones show up on the categories page to help users faster.
	U - As a user, I would like to see videos, links to tutorials, and/or FAQ on the help page so that I can learn how to use the website.
	    Description- This would involve integrating videos into our help documents so that they link to YouTube videos of the actions that we are trying to explain to the user. This will need to be implemented in a clean way without too much activity and clutter. We can use many existing tutorials throughout the internet to link to in an effort to provide a comprehensive library of help topics. This would include a way to search for help topics in an easy way and must have some algorithm to “find” the item that they are looking for and how to prioritize the results that are displayed back to the user. 
=====================================
SOCIAL NETWORKING USER STORIES BELOW
=====================================
E - As a user, I would like to be able to post (text and/or images), comment on my friends posts, and share their posts so I can see what they post and share my opinions.
	U - As a user, I would like to be able to post a status to my profile, and have that post also post to the main page so that my friends can see my posts.
	    Description - On both the home page and a user’s profile page, create a textbox that allows user to type in a text they would like to post, as well as a “post” button once they are ready to post their status. Once “post” is clicked, have this post show up and stay on the user’s profile, and the home page for the user’s friends to see this post. Create a way to delete this post as well. After posting, make a “Delete” button show up that is only authorized for the owner of the post, and once clicked, another prompt that says “Are you sure you would like to delete this post?” and the user can click “yes” or “no”. Once yes is clicked, post will be removed from database and the home page and user’s profile page. Once no is clicked, it will redirect back to the home page or profile (wherever user was at last).
	U - As a user, I would like to be able to post images to my profile so that I can share my pictures with my friends.
	    Description - Add ability to post pictures to a post by adding an icon or link that says “Add picture”. User can both add a text and a picture, or do one or the other (but not neither, do not allow user to post empty status). Once “Add picture” is selected, pop up file explorer on computer so they can find an image to add. Once they select an image, user can choose to post the image/status just like user story that adds a post. User can delete this post like previous user story as well.
	U - As a user, I would like to be able to “like” my friends posts so that I can show them that I liked their status and/or picture they posted.
	    Description - Create “like” button on posts that comes with a picture next to it (thumbs up maybe like Facebook?) that acts as a bool value (you can only like a post once and you can unlike it and bool will be false). This “like” button appears on all posts (after they are posted obviously, not before a post is created) and a user can like anyone’s post that they are friends with (or if they like a page/are part of a group). Since every user can only like a post once, have it show the total number of likes per post next to the “like” button. 
	U - As a user, I would like to see all current posts on my feed (the homepage) from my friends or people/groups that I follow so that I can read what they post in a convenient way, and so that I don’t just have to go to their page to see posts.
	    Description - Make the home page display posts from friends or people that the user is following or a part of a group of. This should be displayed based on most recent posts from friends. This would include a portion of the screen that had a table that could scroll that would list the posts. These posts would be ordered in most popular first and then descending order from there. 
	U - As a user, I would like to be able to have a friends list on my profile page so that I can see who my friends are, and how many friends I have. 
	    Description - This will be a link on a profile page titled “Friends” or “Friends List” that will, by default, be open to the public (or private?) so that people can see who has what friends, and how many friends they have (the privacy settings can easily be changed at any time). The link, once clicked, will take you to a new page that contains a list of friends that a user has. By default, this value will be 0 because nobody has set any connections/friends up yet. 
	U - As a user, I would like to be able to add friends (after searching for them) so that I can have an easily accessible friends list.
	    Description- Create a search bar on the main page (preferably at the top so it is easily accessible and viewed by users) that allows users to search for someone. The result of this search feature should be a redirection to a new page, with a list of potential matching users. The user should then be able to click on a name, get redirected to that person’s profile, and be able to add that person as a friend. This “add friend” feature should be somewhere that can be viewed very easily, like the top of the page by a friends profile picture or name. Once you click “add friend”, text should change to “pending friend request” (or something similar) and the other user should get notified of this pending change. They need to be able to accept or reject the friend request, and if they accept the request, the requester should be notified that they are now friends. The “friends list” should also be updated to reflect this change.
	U - As a user, I would like to be able to comment on my friends posts so that I can share my opinions and have a conversation.
        Description- The comments section of a post should be easily identifiable so that users do not confuse the comments for posts. Each comment may either go down a comment chain or be on one sequential page. Large comment threads might need to be filtered down in some way so that only a few comments show up on the main page until the user clicks on the post. User should be able to hide or report comments that they see are breaking the terms of service or for other reasons.
	U - As a user, I would like to be able to share my friends posts and have it posted to my profile page so that I can share what my friend posted. 
	    Description- Post from friends should be very clear either in the post title or around the title. The way to share a post should be clear and allow users to add text to the post so they can caption it in some way. Before a user shares a post, they should get a window that asks if they want to post it on their profile or just want a link to the post. Users may want to hide shared posts from their ‘feed’ or from the feeds of other users so they can see what the user personally wrote. Links of posts should be clear and show the title of the post in a way that clearly separates it from regular text.

E - As a user, I would like to send a message (or messages) to my friends, people I may know, or people that I just want to talk to so that I can have a conversation with other people in this web app. 
	U - As a user, I would like to be able to send and receive written electronic messages so that I can communicate with other users. 
	U - As a friend, I would like to know when other users that are my friends are online so that I can contact them while they are online. 
	U - As an administrator, I want to be able to remove messages so that we are able to stop harassment or inappropriate situations from occurring at users request. 
	U - As a user, I want to be able to like or give thumbs up to a given message so that I can respond without having to type an entire message. 
	U - As a user, I would like to be able to go back at least 30 days through chat logs so that I can recall what someone said. 
	U - As a user, I would like to be able to ‘favorite’ or lock certain messages so that they cannot be accidently deleted (things like addresses, phone numbers, etc). 
    U - As a user, I would like to be able to attach pictures or videos to my messages so that I can easily send them to another user in a message.  
	
E - As a user, I would like to have a map show my general location so that I am able to see when people are from my general area. 
	U - As a user, I would like to see my general location on a Google Map so that I can get an idea of the general area within my immediate community.  
        Description- This would involve utilizing the Google Maps API. This would map out areas of interest for the user. They would see it on their profile and they would have the ability to click on it and scroll in a ‘live’ view of the area. They could use this tool for a variety of reasons and Bit Breakers can utilize it for statistical data. There would be no additional customization options with the map because we do want to keep the interface as simple as we are able to do. We would utilize the location they input into the DB for themselves as the initial location showing, they would have the option to disable this in their privacy settings. 
	U - As a signed in user I would like to know if other people in my area so that I may meet       up with them. 
        Description- Have a property in the database that keeps track of the individuals location. The individual would have had to make this information available to us. Create a button that finds people near you, by using the information that users have given us, we can develop an algorithm that allows us to track users based on distance and recommends them accordingly. Having the distance be adjustable will also allow clients to customize how far the user is willing to go to meet new friends. (5mi, 10mi, 20mi)
    U - As a user, I would like to see the location of events that are currently being recognized by the site so that I can easily obtain directions to an event. 
    U - As a user, I want the integration of the map to be easy to follow and simple to use so that it doesn’t require advanced knowledge to operate. 
    U - As a hacker, I do not want to be able to obtain log/lat information for a user so that I am unable to violate the privacy policies. 

*API user story below?
E - As a user, I would like to be able to see events near me that interest me, and join that event with a group of people (or friends) who share common interests with me so that I can meet new people and have fun doing an activity I enjoy.
	U - As a user, I would like to be able to search for people that I might know or am trying to find.
	    Description- Create a search bar that parses the database of all active (non-admin, public) users. Display all information in the form of a list and make each list a href (link) that takes the user to that person's profile picture.They then can interact with that profile picture by sending messages or friend requests. The friend request and that process will be included in later iterations. 
	U - As a user, I would like to see the results of a search in a clickable list that identifies them by their profile photo. 
	    Description- This feature would be building a nice layout that shows a table in the middle of the screen that lists the users. This would be by name, profile photo, gender and veteran indicator. This should allow the user to click on a photo of a user or on a name of a user and have it take them to the profile page for that particular page. The level of the information that the searcher would see, would be dependent on the security levels of the other user. This means that someone may be able to see a picture and name, but if they aren’t friends and they have their account as secure, then they will not see ANY profile information.
	U - As a user, I would like to be able to see my friends profile page after searching for them so that I can learn about them and see what they are up to.
        Description- Create a search bar that has searches for all active users in the database. When the user clicks on a profile page and the searcher is a friend to that user. Display their statuses, posts, and public messages for the searcher to see. They will then be able to interact with those items  in the form of comments and likes. 
	U - As a user (admin, business owner, etc), I would like to create a group that can be accessible and joined by anyone so that I can meet with others for various reasons. 
        Description- This feature is essentially the way that people will create events in their area for people to be able to attend. These ‘events’ will be a wide variety of different interactive options for the users. Things like walking groups, cruising groups, physical therapy groups, and grief groups. This list is not exhaustive and there is a lot of room for expansion for the usage of the group feature. This will need to have a clean look that allows for users to easily create groups and post to them, it will need an easy to follow UI with limited ways for user error to be introduced into the process(s). 
	U - As a user (admin, business owner, etc), I would like to be able to post in my group for other members to like, comment, or share so I can advertise my group.
        Description- This would be allowing for advertising from entities such as retirement centers, senior centers or others that have a monetary interest in our user base. This would be similar to the user story directly above, however these will contain more regulation and potentially will become monetized. So if someone is conducting their business there primarily there may be a fee. That would include creating a new entity group to track business owners.We would also have more information registered like business id and things of that nature for businesses that are operating within the social network that is being provided.  
	U - As a user, I would like to be able to “join” or “like” groups so that I can see events going on in those groups that I can later join.
	    Description- This story will require that groups have been created and implemented

E - As a user, I want to be able to find services that pertain me so that I can utilize those services to make my life easier. 
	U - As a user, I would like to be able to access services from the home page so that I can easily navigate to given services. 
	U - As a user, I want to be able to have several options to choose from when picking services so that I can compare and contrast details between the entities. 
	U - As an admin, I want to be able to add new services and remove ones so that we can regulate the site and address any privacy policy violations within the services.  

 E - As a user I would like access to AARP, LYFT, rideshare or any type of product that so that I can go to the events in my community. 
    U - As a user, I would like to be able to access AARP as a resource so that I can utilize their benefits.
	    Description - This will involve adding an AARP tab off of the services tab that was created in a previous epic story. This would allow the user to sign up for AARP if they are not a member and be redirected to their site and help information if that is needed. This page would have imagery that would relate to AARP and the benefits that the service provides.  
	U - As a user, I would like to be able to see the public transport services that are available in my area so that I may improve my mobility
        Description - 
U - As a provider, I would like to see usage information from your site so that we can customize advertisements to the demographic. 
        Description - 
U - As a user, I would like to use the help page to understand some of the services better so that I am able to make informed decisions when choosing which services to utilize. 
        Description - 
	
E - As a user, I would like to be able to see a list of suggested friends that are matched with me personally and would like to be able to follow the stories of other people using the platform so that I can keep up to date on my friends and those who I would like to follow.
	U - As a user, I would like to be able to add people who are near me so that I can make friends that I can also see in person and meet up with them if I want to.
	    Description-

E - As a user, I would like to be able to view news in my area, weather and multiple features amongst services. 
	U - As a user, I would like to be able to see a Google Maps view (or similar product) of an area or event that interests me that will also include providing directions through the mapping interface for me to reach my event or locations of interest throughout the community so that I can, I can see where I need to go.
    	Description-

E - As a user (admin, business owner, etc), I would like to create a mailing list that can be accessible and joined by anyone so that I can mail stuff that interests people who registered.
	U - As a user (admin, business owner, etc), I would like to be able to have users register their address so that only validated persons may access the site. 
	    Description-
	U - As a user, I would like to be able to join a mailing list so that I can receive mail that I enjoy.
	    Description-

E - As a user, I would like to have reminders set up so I can be reminded to take my pills, go to an event I had scheduled, or any event that I need a reminder for so that I will not forget.
	U - As a user I would like to input information for an event that I need to be reminded of (time, place, and description/title of event) so that I do not forget my event. (use google event calendar api for reminders)
	    Description-

E* - As a business, I would like to be able to advertise on the website with products relevant to specific users so I can make money

*Depends on if we implement monetization of the application.
==========================================================================
Agile Data Modeling
[ER Diagram](ERDiagram.PNG)
==========================================================================
 Timeline and Release Plan
=====================================
We intend to follow the continuous release method that has been outline for us to follow (intermittently released every 2 weeks in 2 week sprint cycles). Our release will be hosted on Azure’s Cloud platform throughout the entirety of this project. 
 We will be utilizing Github as a team repository and tracking software to maximize efficiency. All work will be tracked with online tool named Pivotal Tracker. Pivotal will be used to track all EPICS and user stories and also to assign work to developers. We will utilize this tool to track our backlog and use it to prioritize user stories based on Product Owner feedback. Bit Breakers intends to launch our full release in June 2020. 
01/22/2020 - 02/03/2020 ---- Inception and modeling phase
=====================================
Identification of Risks
=====================================
1. If someone makes an account and steal information from users.
2. Risk of personal information being leaked. 
3. User harassment. 
4. Overspending on hosting service (Azure) and having site shut down entirely.
5. If an API becomes private suddenly/changes will effectively render our site useless.
6. Merging conflicts or breaking code (will mitigate with special merge procedures)
7. Continuous deployment could lose old information if we change the database schema. (could lose client information)
8. Technical Debt (minimize this at all costs)


=====================================
Google Docs Link For Updates On This Doc:
https://docs.google.com/document/d/1nFeuD5GrqJQM9sGuCab0LIRFFDGBmADb4iGMEzKOdfE/edit
=====================================
