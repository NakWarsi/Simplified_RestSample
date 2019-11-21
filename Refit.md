#                                            Refit 

### What is Refit?

Refit is a library(Helper Library written in C#) which automatically converts our Rest APIs into a live interface means if we use Refit with our application the user who is using our Rest APIs will never make a mistake in calling the APIs, Refit doesn't only make our users easy to make our API(well that a great Point though) but this also makes our application clean.

### Why Do we Need Refit Library ?

Developer make so many mistakes while calling the rest APIs few of them are as following:-

- Mistake in the selecting the URL,
- Mistake in selecting the object to deserialize the response 
- Mistake in selecting the object to serialize the data which is accepted by the APIs

and their many more mistakes we we use to make like while creating a class for the object(like only one single character mistake in one single field can put you in real trouble). Refit can save us from all of these.
And there is one more benefit of Refit Library I see which is If you are wrapping up your rest APIs with an Interface in contract then they just don't have to dig for the APIs(via swagger etc..) infect they will directly get to know, how many public APIs available.

### **How does  Refit works ?**

you create an Interface with Attributes(attributes defined by Refit like Get, Post, Put, Delete, AliasAs, Body etc..) and automatically creates the Implementation of the Interface to make a complete rest call so user don't have to worry about any thing and can directly call the methods defined in the Interface without worrying about implementation(so user don't have to worry about any thing about rest Business neither the Implementation of the Interface).

### **Let's built project s We can figure out how to use this awesome Library:**

there are few scenarios we have discussed, one API developer can make life of developer using his/her APIs. If this work is done and contract(Library with Refit interface) is shared then the work of developer using these APIs is really done(they don't have to worry at all now, as their work related to Rest have been done by someone) All they need to do is call the method available in Interface.

the other scenario is what if the API developer don't know anything about Refit and all we have is the their numbers of APIs now and their are numbers of developer using these Library. Now probability of mistakes are very high a every one need to create class(Object to deserialize) after looking the Rest APIs(which looks like mostly JSON or XML) in this scenario to reduce the mistake probability one single person can take responsibility of calling all the APIs and understanding everything and provide Interface(Refit) to application developers creating related objects and all.

So let's discuss both of these scenarios one by one:-<br/>
	[Scenario one where **API Developer haven't share any Contract** & You need to use the API with minimum mistakes](https://github.com/NakWarsi/Simplified_RestSample/blob/master/RefitForApiUser.md),<br/>	
	[Scenario two where **You are an API Developer and you don't want API users to struggle** using your Library](https://github.com/NakWarsi/Simplified_RestSample/blob/master/RefitForAPIDeveloper.md)

for More Information about refit [visit at Github Refit Repo](https://github.com/reactiveui/refit)

