# PetOwners
An app to consume the json and output a list of all the cats in alphabetical order under a heading of the gender of their owner.

# Prerequisites 
    Visual Studio 2017

# Steps to Run the App.
    - Clone the code from https://github.com/cserkaran/PetOwners.git
    - Open in Visual Studio 2017 and Build Solution.
    - Make sure PetOwners.UI is set as startup project.
    - Press F5. Console window will appear with the required output.

# Steps to run Tests
    - Open Test Explorer and build solution. 6 Unit tests will be listed.
    - Run the same from Test Explorer. All are passing.

# Project Structure 
    PetOwners.Bll - Contains the Business Logic to sort and group the cat names by their owner gender.
    PetOwners.Infrastructure - Infrastructure code to setup MEF export and import and other platform services.
    PetOwners.Interfaces - Contains Common Interfaces e.g for Repository and AppController.
    PetOwners.Model - Contains Domain Model classes.
    PetOwners.Repository - Repository pattern implementation.
    PetOwners.UI - Console App to read the data from Controller and display. 
    PetOwners.Tests - Unit test projects.

