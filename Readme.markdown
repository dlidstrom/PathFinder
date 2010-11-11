# Introduction

This is an implementation of the [A*](http://en.wikipedia.org/wiki/A*_search_algorithm) search algorithm.
Click twice in the program window and the points will be connected with a line that doesn't
cross any of the previous lines.

# Screenshot

![Sample](https://github.com/dlidstrom/PathFinder/blob/master/shot.png)

# Implementation

The implementation is pretty much the Wikipedia version. I am using the C5 library
because it has a nice priority queue. Tests of the algorithm itself have been made
using [NUnit](http://www.nunit.org/). You'll need Visual Studio 2010, although Express
will do.

Copyright 2010 Daniel Lidström
