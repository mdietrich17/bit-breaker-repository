Guidelines
=====================================

## Code

## C#
1. Use standard C# naming conventions as shown per Microsoft VS documents: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions
2. Use RESTful style when creating controllers (i.e., a new controller for differentiable entities)
3. For every function, write comments above the function. Additionally, any code that needs additional explanations (and is not straightforward), write comments for it. 
4. Put curly braces on their own line, ie:
if(n < 0)
{
 
}
else	
{
 
}

## Javascript
1. Use external script files 
2. Don’t include Javascript in HTML or views. 

## Style
1. Use external CSS files (no in-line CSS) in the HTML 
2. Fonts used for this site are as follows:
3. h1,h2,h3 (size varies): TBD
4. h4,body,p (size varies): TBD

## Database
1. Pluralize table names
2. All tables must be normalized to 3NF 
3. Table primary keys are INTEGER keys labeled as: ID
4. Foreign keys are also INTEGER keys and labeled as: <Entity>ID

## Git
1. Use branches
2. Commit often (don't feel like you have to have made major, complete, changes or new features before committing)
3. Write good commit messages. 
4. Don't commit code that doesn't compile.
5. It's OK to work on a separate testing file in your local repository in order to learn something, but don't keep multiple copies of a real file around just to keep some commented out pieces of code. As long as you have committed often you can always go back anywhere in your history to see what it looked like
6. Don't add and commit any files that are auto-generated (i.e. html documentation, .o, .tmp, ...)
7. Resolve your own merge conflicts by first merging dev into your feature branch and testing thoroughly

## Pull Request Model
1. Before doing any coding, ensure you have pulled the latest changes from the upstream remote repository to your forked repository in both the master and dev branches. Push these changes to your remote repository.
2. Create your feature branches off of the dev branch and do all your development here. Commit often.
3. Once you are ready to merge your work into the overall project, don't. First do the following:
4. Checkout the dev branch and pull any changes that have occurred since you branched.
5. Checkout your feature branch and merge dev into your branch.
6. Fix any merge conflicts.
7. Test thoroughly by building and running the project, making sure everything still looks and works the way you intended.
8. Push your feature branch to your remote repository.
9. From your forked repository on GitHub, create a new pull request:
10. Ensure that the branch you are merging from is your feature branch on your forked repository.
11. Ensure that the branch you are merging into is the dev branch on the upstream repository (you will likely need to change this from master to dev).
12. Fill out the title and description fields as necessary.
13. If you are no longer going to be working on this feature branch, feel free to check the box to close the branch after the pull request is merged.
14. Create the pull request.
15. If you continue to work on this feature branch before the pull request is accepted, or if the upstream repository suggests any changes before the merge, you can still make changes on your branch and push them to your remote repository. Doing so will automatically update your pull request.
16. Once your pull request is accepted and merged, pull the updates to your local dev branch and push to your remote repository.

## Team Rules
1. Communicate often. If there is a problem, whether that be with the GitHub workflow, coding problems, misunderstanding a task that needs to be done, or some internal teammate conflict, we must all communicate in order to resolve these conflicts. After all, we are a team.
2. Follow the Git workflow. See “Git” in Guidelines markdown file.
3. Be accountable, do the work you’re assigned. 
4. Be forthcoming with any issues that arise.
5. No negative talk about team members outside of group meetings. 

## Team Song
1. The team song that Bit Breakers chose to represent both their project, Simply Seniors, and their organization overall, would be that of My Generation. We are using this because it was about the golden generation and sung by users that may use this site. The link to this song can be found at https://www.youtube.com/watch?v=zqfFrCUrEbY.
2. We also chose Human as a possible candidate for our team song, as the beat would work very well with us walking up to the stage during the showcase. The link to this song can be found at https://www.youtube.com/watch?v=L3wKzyIN1yk. 