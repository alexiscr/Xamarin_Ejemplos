- Para este ejemplo es necesario actualizar el Nuget de Xamarin Forms a la version Pre Release 4.0
- Luego de actualizado es necesario reiniciar la solución.
- Para poder proceder a depurar la aplicación con la CollectionView es necesario habilitar la parte experimental, 
para ello es necesario agregar en el MainActivity.cs del proyecto Android la siguiente linea de código.

// Linea a agregar
global::Xamarin.Forms.Forms.SetFlags("Shell_Experimental", "Visual_Experimental", "CollectionView_Experimental");
//Linea guía en donde se sebe colocar la linea anterior
global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

Fuentes:
https://docs.microsoft.com/en-us/xamarin/xamarin-forms/release-notes/4.0/4.0.0-pre4