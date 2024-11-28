-> ACT2

=== ACT2 ===

/*
1. Initial Setup (while black screen)
*A few days later you log in to the YapChat! again. You are trying to contact Sam, but he is not online.*
(fade-in to website again)

2. Notification from Riley
(After a moment, a new message pops up from Riley)
*/

// Riley introduction
= stitch1
Hey!

I saw that you were online. Thought I'd say hi, since we haven’t really gotten a chance to talk to each other yet.

    * Hi. Remind me. Who are you again?
        Oh, I'm Riley. 
        I sent you a friend request a few days ago. 
        I just love meeting new people on here, so hope you won’t mind chatting, and sharing some stuff from the feed.
        -> stitch2
        
    * Do I know you?
    Oh, I'm Riley. 
        I sent you a friend request a few days ago. 
        I just love meeting new people on here, so hope you won’t mind chatting, and sharing some stuff from the feed.
        -> stitch2
    
    * Oh hi. Sure, we can talk.
    Nice, nice. 
    I just love meeting new people on here, so hope you won’t mind chatting, and sharing some stuff from the feed.
        -> stitch2


// Engage with Riley
= stitch2        
VAR willToShare = false

* Not really interested.
    -> stitch4
    
* Won’t mind at all.
    Awesome! Does your feed have some good stuff?
    ** Sure do. I can try and share something with you
        ~ willToShare = "true"
        Pls do :) 
        -> stitch3
    ** I would say so. Give me a sec to find something
        ~ willToShare = "true"
        Ok. i'll wait.
        -> stitch3
    ** Not really.
        Bummer. Well, i'll go ahead and share something with you then. Should hopefully get your algorithm up and running so that your feed gets a little more interesting.
                *** You don't have to do that. That's not necessary.
                    You'll like it. Trust me
                    -> stitch4
                *** Sure, go for it.
                    ~ willToShare = "true"
                    Ok. Just give me a sec.
                    -> stitch4
                *** Algorithm? What is an algorithm?
                    Umm....
                    well...
                    An alogithm is basically a system that tries to make sure you see content that you are actually interested in.
                    So like, it monitors what posts you engage with and then uses that information to give you more of / similar posts in your feed  
                    **** Huh. Sounds pretty intrusive
                    **** Interesting.
                    ---- Nah. Don't think about it. All social media has something like that integrated. Almost unavoidable at this point. Anyway. I found a good one for you.
                        -> stitch4
        
* I guess I don't mind.
    Cool.
    Getting anything good on your feed you would mind sharing? 
    I can also share something from my feed if you would prefer that? Just to break the ice.
        ** Sure. Just give me a sec and i'll send you something.
            ~ willToShare = "true"
            Epic.
            -> stitch3
        ** I’d prefer not to share anything, but you are welcome to share something if you want.
            That's ok. I'll share something from my feed i think you'll like.
            -> stitch4
        ** My feed is pretty boring so you just go ahead.
            Bummer. Well, i'll go ahead and send you something. Should hopefully get your algorithm up and running so that your feed gets a little more interesting.
                *** You don't have to do that. That's not necessary.
                    You'll like it. Trust me
                    -> stitch4
                *** Sure, go for it.
                    ~ willToShare = "true"
                    Ok. Just give me a sec.
                    -> stitch4
                *** Algorithm? What is an algorithm?
                    Umm....
                    well...
                    An alogithm is basically a system that tries to make sure you see content that you are actually interested in.
                    So like, it monitors what posts you engage with and then uses that information to give you more of / similar posts in your feed  
                    **** Huh. Sounds pretty intrusive
                    **** Interesting.
                    ---- Nah. Don't think about it. 
                    All social media has something like that integrated. 
                    Almost unavoidable at this point. 
                    Anyway. I found a good one for you.
                    -> stitch4
                

= stitch3
VAR sharedRileyPost = 0

//0-2 Riley means it. 3-4 Riley is sarcastic or "plays along"
{sharedRileyPost:
- 0: Haha. Nice one. I think i can beat it however.
- 1: Sorry to say, but that was kind of lame. 
- 2: Interesting. Reminds me of something like this.
- 3: haha. nice one. But just you wait till you see this one
- 4: interesting.
}

-> stitch4

= stitch4
VAR shareTopic = 0

/*
4. Rileys Share
(Riley either brings up a theme based on what the player shared or based on the feed interaction score. Riley will choose one of the three: anxiety, grind culture, or body image.)
*/

{willToShare == true:
    Here, check out this one.
    }

(Riley shares a post)

{shareTopic:
- 0: ->stitch5
- 1: ->stitch6
- 2: ->stitch7
}
    
// Anxiety
= stitch5


-> DONE

// Grind Culture
= stitch6

-> DONE

// Body Image
= stitch7

-> DONE

->END