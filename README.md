# Xamarin Forms Complete Starter Project
A light weight starter project for Xamarin Forms

# Why?
As with most technologies the default sample projects only ever show the simplest way to do things. But if you need to develop a production quality application you have no idea on the best approach. And maybe that is because the great thing about programming is you can choose so many approaches why would you limit yourself.

However for the projects I have worked on over the year, here is the default architecture I have settled on. Changes may need to be made with each project but it is a good solid base to start from.

# Project Capabilities
All projects I have developed have shown the need for these :

1. MVVM Framework
2. API Connectivity
3. Local Storage
4. ServiceLocator
5. Constructor Dependency Injection

# Dependencies
I have tried to keep dependencies down to a minimum. There are a lot of different components and packages you can add, each having their different strengths. I chose these packages due to their necessity and/or low footprint.

1. MVVMLight Libs
2. AutoMapper
3. Microsoft HTTP Client Libraries
4. Settings Plugin For Xamarin
5. Newtonsoft Json

# Conventions

ViewModels are loaded on a convention basis. They must be in the namespace Mobile.ViewModel and the class name must end in ViewModel. They will then be automatically loaded.

# Personal Preferences

1. I love using XAML, hence this project will use XAML for all views.
2. While Shared Code may have its place, I never found a solid use case for it in my projects. PCL is my preferred approach.
3. I use Visual Studio for Xamarin development with a Mac Build Host (mini mac's are great for this)
