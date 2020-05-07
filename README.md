# DigiDex
![Image of DigiDex logo](https://i.imgur.com/nEBF7vf.jpg?1)

## Table of Contents
* [What is DigiDex?](#What-is-DigiDex)
* [How to use DigiDex](#How-to-use-DigiDex)
* [Getting Started](#Getting-Started)
* [Contact Us](#Contact-Us)
* [Acknowledgements and Resources](#Acknowledgements-and-Resources)


## What is DigiDex?
DigiDex is an API that allows people to digitally create and organize their own decks of sport or game cards.

## How to use DigiDex
Users begin by creating categories, adding decks to the categories, and adding individual cards to their decks. Every card must be in a deck, and every deck must be in a category.
Users can search by title or ID for specific cards, decks, and categories, or view all cards in their collection or all cards in a deck or category. Users can update cards, decks, and categories, as well as move cards to other decks and move decks to other categories to keep the collection organized. They may also delete cards, decks, and categories. Category titles cannot be duplicated, and deck titles cannot be duplicated within a category, though they can be duplicated if they are in different categories. Card titles can be duplicated in any deck. 

## Getting Started
DigiDex Web API was created using C# and .NET Framework (v 4.8) in Microsoft Visual Studio Community 2019.
  * Prerequisites:
  
    Users should have [Visual Studio Community](https://visualstudio.microsoft.com) installed and an API client such as [Postman](https://www.postman.com/).
  
  * Installation:
   1. Clone the latest version of Digidex at https://github.com/kmpcool123/DigiDex
   2. In Visual Studio Community, install:
  ```
      Microsoft.AspNet.Identiy.EntityFramework
  
      Microsoft.AspNet.Identity.Owin (required only for the Data layer)
  
      Microsoft.AspNet.WebApi.Owin (required only for the Data layer)
```
  3. Run the application in Visual Studio Community
  4. In the API client, register a new user (email address, password, and confirm password), and get a bearer token for user authorization.
  5. Use the applicable URI and endpoints to Post, Get, Put, and Delete to create and edit the card collection.

## Contact Us
Contributors:
* Khalil.perkins98@gmail.com
* jonathan.ingersoll@gmail.com
* erin.croteau@gmail.com

Project Repository: https://github.com/kmpcool123/DigiDex

## Acknowledgements and Resources

- [Microsoft Docs  .NET  ASP.NET 4.x  Web API](https://docs.microsoft.com/en-us/aspnet/web-api/)

- [README Template](https://github.com/othneildrew/Best-README-Template)

- [Markdown Formatting](https://guides.github.com/features/mastering-markdown/)

- [Eleven Fifty Academy (Software Development Course)](https://elevenfifty.org/)
