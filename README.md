# Web API prototype project
This repository stores a REST API project. It is a small prototype that is similar to a real project, that will be relevant for the back-end position.

Below is a few tasks that we have prepared for you. We only expect you to spend a few hours on this – not days. The most important is for us to get a little insight into your understanding/thinking. We ask you to do the following:

1. Clone this repo and see how the application is working.
2. Review the code base and evaluate the code and how it could be improved.
3. Make some relevant changes and comments with your thoughts and explanations.
4. More overall thoughts/suggestions/ideas for the code or architecture can be added below in this README.
5. Make a pull request with your changes.
----
#### General thoughts/suggestions/ideas can be added here:

I have no experience with Unity; I've understood that it is an IoC framework - but have not looked further into it, and will - for now - optimistically assume "that everything's fine" regarding the setup and use of it. 



### Major bad stuff

- Be able to run the solution
  - May just be a matter of providing a `HomeController` - but other issues may also be lurking. 
- Logic for saving books is wrong. 
  - No error-handling when inserting / updating / deleting in DB? For instance when deleting a book, true is returned (as an indication of succesfull insertion), even if it (the insert operation) fails. 
    Absorbing errors (I'm thinking of `SaveChanges()` in `BaseRepository`) is a dangerous path, if not straight  up simply wrong.
    - Additionally: The generated `errorMessages` is used for…nothing! 
- Don't expose domain-models, i.e. don't expect clients to use domain-model in transfer. Create DTOs. 
- `BookController`: For delete-operations, don't use `[HTTPPost]` but rather `[HTTPDelete]`
- **Restructure project!!** 
  What's the point of having separate Interfaces, Implementation, Models and Repository projects when they are all consumed in one place anyway? 
- Is this both a REST API and an MVC app?
  - If only a REST API, I suggest naming it (the solution) `BookAPI`
- Inconsistent structure when reviewing `Areas/` folder. Multiple patterns for structure in play - don't stick to multiple structures, rather stick to one!
- I'ld want to verify that the `[EnableCors(origins: "*", headers: "accept,Auth-Key", methods: "*")]` annotated on `BookController` truly is sensible; I suspect it's not 😕
- Delete `HelpPage` if possible; I suspect it is from scaffolded MVC-project...? 
- The absence of automated tests

### Medium bad stuff

- Unless by developer's agreement / self-defined convention (for some reason), re-specifying `[Route("")]` is not necessary when it matches name of controller-method. 
- On models, use data-annotations to describe what properties are required, and use `ModelState.isValid` for verification of payload. 
- Error-code (`1`) used in `BookController` (when no book-match was found) seems odd; stick to the commonly known language of HTTP-status codes. 
- I would not use exceptions when a matching entry is not found - this is not to be considered an exceptional situation; this is a totally valid situation as we have no control of what hits the API and this (querying for a non-existing ID) is not exceptional. 
- The JSON-formatter defined in *BookController* should probably be globally accessible (and put in one place only), since it is copy-pasted into `UserController` also. 
- `BookController` defines an empty constructor; using it will create faulty instances of `BookController` (since no BookService is provided then)
- Why is `BaseRepository` declared `[Serializable]`?
- What is the point of `BookExtended` in general? Why not inherit? What's the intent of `MoreUserBooks`? 
- Move content of  `fonts/` to `Content/` folder and rename `Content/` to `Assets/`
- Rename "Results" folder to something more descriptive…Clarify what the intended content is!
- Don't mix ViewModels and Models
- What's going on in the constructor of `User`??
- Decide if we want / need a `HomeController` or not. "Home" is referenced in `RouteConfig.cs`. 

### Minor stuff

- Not a fan of *not* using braces `{` and `}` - even for single line statements.

- Please untangle the responsibilities of `UserController` and `BookController` !! With little knowledge about the domain, it still seems odd to me that one can create a book without registering the user of that book. 

- Delete `Class1.cs`

- Domain-model `Book` should not both contain a `UserID` and a `User`

- Delete all unused `using` statements. 

- Naming conventions for private readonly fields dictate starting in underscores, ie.

  ```c#
  // private readonly IBookRepository BookRepository; 
  private readonly IBookRepository _bookRepository;
  ```