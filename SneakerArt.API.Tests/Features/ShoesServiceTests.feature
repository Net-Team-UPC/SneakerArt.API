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
 	

@shoe-getting
Scenario: Get list of Shoes
	Given the Endpoint https://localhost:44379/api/v1/shoes is available
	When a Get Request is sent
	Then A Response is Received with Status 200
	And a Shoe Resource is included in Response Body
	  | Id | Name                        | Description                                                                  | Price | Img                                                                                       |
	  | 1  | Nike Air Force One blue     | Personalized painted blue drip style slippers Available in sizes from 28 -43 | $50   | https://i.etsystatic.com/28924822/r/il/266da9/3400342986/il_fullxfull.3400342986_oh75.jpg |
	  | 2  | Adidas superstar shark      | Personalized brown shark style sneakers Available in sizes 36 to 42          | $60   | https://i.pinimg.com/originals/9d/1f/b4/9d1fb4c2df48dd9726deca53db5b0efc.jpg              |
	  | 3  | Converse all star feather   | Personalized light blue feather style slippers Available in sizes 28 to 43   | $55   | https://i.pinimg.com/originals/d8/72/da/d872da61a31ecb0901869056d5a8d935.jpg              |
	  | 4  | Kakashi Sneakers            | Personalized Kakashi Sneakers available in sizes 8 to 9.5 US                 | $70   | https://www.dhresource.com/0x0/f2/albu/g18/M00/2A/29/rBNaNmEXbR6AVgItAAGfK-Ikzlc543.jpg   |
	  | 5  | Nike Multicolor             | Personalized Nike Multicolor Available in sizes 8 to 9.5 US                  | $50   | https://i.pinimg.com/236x/77/2b/3c/772b3cb40434604c67b45b81d065136c.jpg                   |
	  | 6  | The Simpsons Nike Air Force | Personalized The Simpsons Nike Air Force available in sizes 8 to 9.5 US      | $70   | https://i.etsystatic.com/21722038/r/il/1aca43/4039489801/il_1080xN.4039489801_po7k.jpg    |	
#@shoe-updating
#Scenario: Update Shoe by ID
#	Given the Endpoint https://localhost:44379/api/v1/shoes/1 is available
#	When a Put Request is sent with the following data
#	  | Name              | Description              | Price | Img                                   |
#	  | Updated Shoe Name | Updated Shoe Description | $60   | https://example.com/updated-image.jpg |
#	Then A Response is Received with Status 200
#	And the Shoe Resource with ID 1 is updated with the following data
#	  | Id | Name              | Description              | Price | Img                                   |
#	  | 1  | Updated Shoe Name | Updated Shoe Description | $60   | https://example.com/updated-image.jpg |
#@shoe-deleting
