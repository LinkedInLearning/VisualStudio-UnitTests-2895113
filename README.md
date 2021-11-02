# Visual Studio Deep Dive: Unit Tests
This is the repository for the LinkedIn Learning course Visual Studio Deep Dive: Unit Tests. The full course is available from [LinkedIn Learning][lil-course-url].


If you are a responsible programmer, you regularly test your code to make sure it behaves the way you expect it to behave. Unit tests are the most common type of developer test, and most programmers rely on a unit test framework to create and run those tests. In this course, Walt Ritscher takes a deep dive into the unit test tools available in Visual Studio. Walt gives an overview of unit tests and how they integrate with Visual Studio, then takes a deeper look into unit tests with MSTest and xUnit framework and how each is fully integrated into the Visual Studio Test Explorer, He also reviews additional Visual Studio test features like CodeLens, Live Unit Testing, and code coverage.

## Instructions
This repository has branches for each of the videos in the course. You can use the branch pop up menu in github to switch to a specific branch and take a look at the course at that stage, or you can add `/tree/BRANCH_NAME` to the URL to go to the branch you want to access.

## Branches
The branches are structured to correspond to the videos in the course. The naming convention is `CHAPTER#_MOVIE#`. As an example, the branch named `02_03` corresponds to the second chapter and the third video in that chapter. 
Some branches will have a beginning and an end state. These are marked with the letters `b` for "beginning" and `e` for "end". The `b` branch contains the code as it is at the beginning of the movie. The `e` branch contains the code as it is at the end of the movie. The `main` branch holds the final state of the code when in the course.

When switching from one exercise files branch to the next after making changes to the files, you may get a message like this:

    error: Your local changes to the following files would be overwritten by checkout:        [files]
    Please commit your changes or stash them before you switch branches.
    Aborting

To resolve this issue:
	
    Add changes to git using this command: git add .
	Commit changes using this command: git commit -m "some message"

## Installing
1. To use these exercise files, you must have the following installed:
	- [list of requirements for course]
2. Clone this repository into your local machine using the terminal (Mac), CMD (Windows), or a GUI tool like SourceTree.
3. [Course-specific instructions]


### Instructor

Walt Ritscher 
                            
Senior Staff Author

                            

Check out my other courses on [LinkedIn Learning](https://www.linkedin.com/learning/instructors/walt-ritscher).

[lil-course-url]: https://www.linkedin.com/learning/visual-studio-deep-dive-unit-tests
[lil-thumbnail-url]: https://media-exp1.licdn.com/dms/image/C560DAQG0HGgFG-r2hg/learning-public-crop_675_1200/0/1628100439374?e=1628614800&v=beta&t=XvWp1tx0s_HYZHUumJ8ra8yxI7dcvHL9XpN1W2th2-M
