# BonAppetit (Lore)
Do you like ordering food from you phone, well covid restrictions now are allowing us to go out, finally. So going out is a must for many reasons, 
Imagine you are a Restaurant owner and you want to have an easier way to handle reservation requests 24/7.

# The Problem
people want comfort, the confort for a potential client to search for restaurants as you do for food on Uber eats or Skip the dishes,
that is the services bon appetit offers.

# The Solution
Microservice architecture with Event driven design (not Event sourcing, that's very different, but coming soon), Restaurants can register by creating an account
and adding the necessary information, Schedule of operations (if they are open, then provide the opening and closing hours for each week day), 
adding the tables with some metadata and important operational information like, the amount of seats, the frequency of reservation.

The Client App consumes this information and handles requests through api requests that trigger the messaging pattern and update the database.

#Technologies
.Net 6 with C#
Entity Framework core,
Duende Identity server 6,
Rest apis,
RabbitMq,
Stripe payment platform,
Blazor Web assambly,
Best practices.
