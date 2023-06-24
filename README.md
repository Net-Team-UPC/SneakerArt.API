# SneakerArt.API
## Team: Net Team
Members
* Franco Surco Reyes - U202015132
* Piero Stefano Márquez - U201816402
## Rider
JetBrains Rider is a cross-platform .NET IDE based on the IntelliJ platform and ReSharper.

## ASP.NET Core
ASP.NET Core is the open-source version of ASP.NET, that runs on macOS, Linux, and Windows. ASP.NET Core was first released in 2016 and is a re-design of earlier Windows-only versions of ASP.NET.

the API was created to exchange information with the SneakerArt web application.
you can access the deployed API here: http://deployapliweb123-001-site1.etempurl.com

## Endpoints
Shoes
* GET /api/v1/shoes: Gets all available shoes.
 * POST /api/v1/shoes: Creates a new shoe.
 * PUT /api/v1/shoes/{id}: Updates an existing shoe according to its identifier.
 * DELETE /api/v1/shoes/{id}: Deletes an existing shoe according to its identifier.
Designs
*  GET /api/v1/designs: Gets all available designs.
*  POST /api/v1/designs: Creates a new design.
*  PUT /api/v1/designs/{id}: Updates an existing design according to its identifier.
*  DELETE /api/v1/designs/{id}: Deletes an existing design according to its identifier.
 Comments
*  GET /api/v1/comments: Gets all available comments.
 * POST /api/v1/comments: Creates a new comment.
  * PUT /api/v1/comments/{id}: Updates an existing comment according to its identifier.
 * DELETE /api/v1/comments/{id}: Deletes an existing comment according to its identifier.
Profiles
*  GET /api/v1/profiles: Gets all available profiles.
*  POST /api/v1/profiles: Creates a new profile.
*  PUT /api/v1/profiles/{id}: Updates an existing profile according to its identifier.
*  DELETE /api/v1/profiles/{id}: Deletes an existing profile according to its identifier.
