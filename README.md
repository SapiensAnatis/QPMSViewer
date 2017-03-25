# QPMSViewer MVVM branch

As I envision that this project will get quite complex in terms of interface requirements, I've decided to adopt the MVVM model while the project is young; the idea being to minimize the work to do so.

MVVM, MVC, etc. are a similar group of concepts that essentially convey that the UI (View) and the Model (calculations) should bind to a controller (C, or ViewModel, VM in C#) that mediates interactions between them. Remembering the mess that was Duck Hunt made me immediately realise why this was a good idea. In that application, because I had AI I was calculating their positions and then wanting to update the UI from classes that weren't my Window. This caused issues with the threading (UI can only be updated from a particular thread) and complicated the codebase massively, which is a large reason as to why I didn't finish it.

