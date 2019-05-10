# Robot War

This a code test I made on 22/04/2019.  
It is the result of some hours of work. Can be improved.  
  
Instead of the common console application I decided to create a library.  
In a real world scenarion this library can be used by different kind of UI, mobile, desktop or websites.  
  
_Game_ is the only object that should be used by third party projects.  
It is an interface, _IGame_, because it can be mocked and injected to facilitate tests.  
I haven't created other interfaces because I didn't see the needs, at least at this stage.  
  
In a real scenario the input is passed to the __Run__ method so I created a static method, _CreateGame_, to read and parse the text input.   method


