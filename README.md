# Happy Headlines-
under development

Happy Headlines is a global media technology company with a clear mission: to spread positivity by sharing uplifting news from around the world. Founded a decade ago by a group of visionary journalists and software engineers, the company has since grown into a digital powerhouse, serving millions of daily users across all continents.

# First Week Assigment
Do C4 diagram for a WebApp Called Happy Headlines

C1- context 
C2- container

# Second Week Assigment

Implement the ArticleService and the ArticleDatabase. The ArticleService needs four endpoints for Create, Read, Update and Delete. It must be implemented as a REST-based API.

You have to perform a x-axis split on the ArticleService so that three instances are available with a load balancer to take care of which instance will service the incoming request.

Furthermore you have to perform a z-axis split on the ArticleDatabase such that each continent has their own database. Along with the seven continent database an eighth database will contain news articles that’s relevant across the entire world - a global database so-to-speak.