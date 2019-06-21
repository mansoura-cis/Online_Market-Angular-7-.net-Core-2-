# In The Name OF ALLAH
---
## CORS
---


- Enabling __CORS__
 - Although you may not notice it, the web pages you visit make frequent requests to load assets like images, fonts, and more, from many different places across the Internet. 
 - If these requests for assets go unchecked, the security of your browser may be at risk.
   -  For example, your browser may be subject to hijacking, or your browser might blindly download malicious code. 
- As a result, many modern browsers follow security policies to mitigate such risks.

- >  We must Enable its services
```
services.AddCors(options =>
            {

             options.AddPolicy("EnableCORS", builder =>
                {
                   builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });
        }
```
- > and adding its App  
``` 
App.AddCors("EnableCORS");
```
     