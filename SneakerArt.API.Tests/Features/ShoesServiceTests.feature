Feature: ShoesServiceTests
	As a Developer
	I want to add a new Shoe through API
	In order to make it available for applications.

	Background: 
		Given the Endpoint https://localhost:44379/api/v1/shoes is available
	
@shoe-adding
Scenario: Add Shoe with unique data
	When a Post Request is sent
	| Name                    | Description                                                                  | Price | Img                                                                                       |
	| Nike Air Force One blue | Personalized painted blue drip style slippers Available in sizes from 28 -43 | $50   | https://i.etsystatic.com/28924822/r/il/266da9/3400342986/il_fullxfull.3400342986_oh75.jpg |
	Then A Response is Received with Status 200
	And a Shoe Resource is included in Response Body
	| Id | Name                    | Description                                                                  | Price | Img                                                                                       |
	| 1  | Nike Air Force One blue | Personalized painted blue drip style slippers Available in sizes from 28 -43 | $50   | https://i.etsystatic.com/28924822/r/il/266da9/3400342986/il_fullxfull.3400342986_oh75.jpg |
 	
