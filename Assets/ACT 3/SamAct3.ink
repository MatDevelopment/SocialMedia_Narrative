-> SamAct3

=== SamAct3 ===

// Intro
=stitch1
VAR RileyConnected = false
VAR sam_support = 0
VAR riley_influence = 0

{RileyConnected == true:
    // Act 2 ended with Riley connection
    Hey. 
    
    Look, I know it’s been a while since we talked. 
    
    I haven’t been online much, and I guess you probably noticed that. 
    
    It’s not that I didn’t want to
    
    I just needed a break from everything.
    
    Things are just a mess right now, and I don’t know what to say.
    
    *   Of course. What’s going on?
        ~ sam_support += 2
        -> stitch2
    *   I’m here now. What’s up? 
        -> stitch3
    *   Just say it 
        ~ riley_influence += 2
        -> stitch4
}
{RileyConnected == false:
    // Act 2 ended without Riley connection
    Hey. 
    
    I know I’ve been out of touch. 
    
    And I don’t blame you if you’re frustrated or confused about it. 
    
    Honestly, I’m just trying to figure things out for myself. 
    
    I don’t have a good excuse. 
    
    Things are just a mess right now, and I don’t know what to say.

    Can we meet up? Or at least talk properly? 
    
    *   What happened, Sam? You just disapeared all of a sudden?
        ~ sam_support += 1
        -> stitch2
        
    *   I’m here now. What’s up?
        -> stitch3
    
    *   I’m kind of busy right now. 
        ~ riley_influence += 2
        -> stitch4
}

// First conversation
// Supportive
= stitch2
{RileyConnected == true:
->DONE
}
{RileyConnected == false:
It's just that for the past few days thing have kind of gone to shit for me and my family.

After we spoke last time, we got a call from the hospital that my dad had been sent to the emergency room, due to an accident at work.

He is fine now, but we really didn't think he was gonna make it, when they initially called. 

I'm still kind of on edge from this whole experience and could really use a friend right now, so I would appreciate it if we could meet somewhere.

* Of course we can meet up. Any particular place you had in mind?
    ~ sam_support += 2
    ->DONE
* Well I'm here. What difference does it make if I'm there?
    ~ riley_influence += 2
    -> DONE





->DONE
}

// Neutral
= stitch3
{RileyConnected == true:
->DONE
}
{RileyConnected == false:
As 
->DONE
}

// Dismissive
= stitch4
{RileyConnected == true:
->DONE
}
{RileyConnected == false:
->DONE
}


// Second conversation


->END




