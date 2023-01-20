CREATE TABLE [dbo].[Flights]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AirlineName] NCHAR(100) NOT NULL, 
    [FromCityId] INT NOT NULL, 
    [DestinationCityId] INT NOT NULL, 
    [Distance] INT NOT NULL, 
    [FlightDuration] INT NOT NULL, 
    [KmPrice] INT NOT NULL, 
    CONSTRAINT [FK_Flights_From_Cities] FOREIGN KEY ([FromCityId]) REFERENCES [Cities]([Id]), 
    CONSTRAINT [FK_Flights_Destination_Cities] FOREIGN KEY ([DestinationCityId]) REFERENCES [Cities]([Id])
)
