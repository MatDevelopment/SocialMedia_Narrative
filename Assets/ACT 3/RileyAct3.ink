INCLUDE GlobalVariables.ink

-> RileyAct3

=== RileyAct3 ===

// Intro
=stitch1
{RileyConnected == true:
// Act 2 ended with Riley connection
// Sam writes after talking with Riley in act 3

{ShareTopic == 0: //Anxiety
    Hello Hello! 
    Did you see the latest news?
        * No, what has happened?
        ->DONE
        * I did. Crazy stuff.
        ->DONE
}

{ShareTopic == 1: //Grind Culture
    sdsdsdsd
        * sdsds
        ->DONE
        * sdsdsd
        ->DONE
}

{ShareTopic == 2: //Body Image
    sdsd
        * sdsd
        ->DONE
        * sdsdsd
        ->DONE
}
}


{RileyConnected == false:
// Act 2 ended with Riley connection
// Sam writes before talking with Riley in act 3
->DONE
}



->END