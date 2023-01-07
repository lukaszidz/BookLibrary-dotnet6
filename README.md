
# Book Library

Simple book library project, using .NET 6, React and MS SQL Server database. The primary functionality is a filtering books by set of attributes (title, publisher, author, etc.)


## Screenshots

![image](https://user-images.githubusercontent.com/12186634/206858765-0f2ce44e-84f6-4e14-9722-c47135a1db2d.png)

![image](https://user-images.githubusercontent.com/12186634/206859300-9eb7a2ea-ca8c-406a-b095-824c022a9f79.png)

API:

![image](https://user-images.githubusercontent.com/12186634/206859334-2fce3d7f-7112-4b5d-a947-401a579786bb.png)
## Architecture

**Server:** The Clean Architecture. It consists of following projects:
- **BookLibrary.API** – Runs the .NET Api and exposed all endpoints via controller.
- **BookLibrary.App** – Application layer based on CQRS implementation by using MediatR library. 
- **BookLibrary.Core** – Domain entities and adapters.
- **BookLibrary.Infrastructure** – Contains mostly the specific database repository implementation.
- **BookLibrary.Utils** – A Common project with custom components and extension reusable across above projects.

**Client:** React. It contains:

- components – Custom, resuable and business specific components.
- api - Functions required to handle API requests and errors
- styles - CSS files.


## Run on Local
### Api:

Run in the *root* folder.

```bash
# build the database
update database
```


```bash
# run the API
dotnet run
```

By default it runs on https://localhost:7178


### Client:

Run in the *UI* folder.

```bash
npm start
```

By default it runs on http://localhost:3000

### Seed sample data:

Example data are located in the *api-seed* folder. Run one by one by calling the POST endpoint:
```curl
POST https://localhost:7182/api/Book
```
