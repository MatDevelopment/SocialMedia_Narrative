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
Hey! #speaker:Riley #portrait:riley #layout:left

I saw that you were online. #speaker:Riley #portrait:riley #layout:left
Thought I'd say hi, since we haven’t really gotten a chance to talk to each other yet. #speaker:Riley #portrait:riley #layout:left

* Hi. Remind me. Who are you again? #speaker:Player #portrait:player #layout:right  
    Oh, I’m Riley! #speaker:Riley #portrait:riley #layout:left  
    I sent you a friend request a few days ago. #speaker:Riley #portrait:riley #layout:left  
    I love meeting new people here. Hope you don’t mind chatting? #speaker:Riley #portrait:riley #layout:left  
    -> stitch2

* Do I know you? #speaker:Player #portrait:player #layout:right  
    Oh, I’m Riley! #speaker:Riley #portrait:riley #layout:left  
    I sent you a friend request a few days ago. #speaker:Riley #portrait:riley #layout:left  
    I’m always excited to connect with new people. Mind if we chat? #speaker:Riley #portrait:riley #layout:left  
    -> stitch2

* Oh hi. Sure, we can talk. #speaker:Player #portrait:player #layout:right  
    Nice, nice. #speaker:Riley #portrait:riley #layout:left  
    I’m always happy to meet someone new! #speaker:Riley #portrait:riley #layout:left  
    -> stitch2



// Engage with Riley
= stitch2        
VAR willToShare = false

* Not really interested. #speaker:Player #portrait:player #layout:right  
    Oh, no worries. I get that. #speaker:Riley #portrait:riley #layout:left  
    I could still share something cool with you if you’re okay with that? #speaker:Riley #portrait:riley #layout:left  
    -> END

* Sure, I don’t mind. #speaker:Player #portrait:player #layout:right  
    Awesome! #speaker:Riley #portrait:riley #layout:left  
    Have anything interesting on your feed to share? #speaker:Riley #portrait:riley #layout:left  
    Just to break the ice a bit. #speaker:Riley #portrait:riley #layout:left  

    ** Yeah, give me a sec to find something. #speaker:Player #portrait:player #layout:right  
        ~ willToShare = true  
        Cool! Can’t wait to see. #speaker:Riley #portrait:riley #layout:left  
        -> stitch3  

    ** Not really. My feed’s kind of boring. #speaker:Player #portrait:player #layout:right  
        Bummer. #speaker:Riley #portrait:riley #layout:left  
        I’ll share something with you to spice it up! #speaker:Riley #portrait:riley #layout:left  
        -> END

    ** Not really. #speaker:Player #portrait:player #layout:right  
        What about you? Got anything cool to share? #speaker:Player #portrait:player #layout:right  
        Of course! I’ve got a ton of interesting stuff. #speaker:Riley #portrait:riley #layout:left  
        Here, let me find something. #speaker:Riley #portrait:riley #layout:left  
        -> END

* Maybe. What kind of stuff are you into? #speaker:Player #portrait:player #layout:right  
    Oh, a little bit of everything—funny memes, interesting articles, deep stuff. #speaker:Riley #portrait:riley #layout:left  
    If you’re down, I can send you something cool! #speaker:Riley #portrait:riley #layout:left  

    ** Sure, send something over. #speaker:Player #portrait:player #layout:right  
        ~ willToShare = true  
        Alright, let me grab something for you. #speaker:Riley #portrait:riley #layout:left  
        -> END  

    ** I’ll see if I have something to share too. #speaker:Player #portrait:player #layout:right  
        ~ willToShare = true  
        Great! Looking forward to it. #speaker:Riley #portrait:riley #layout:left  
        -> stitch3  

                

= stitch3
VAR sharedRileyPost = 4

//0-2 Riley means it. 3-4 Riley is sarcastic or "plays along"
{sharedRileyPost:
- 0: Haha. Nice one. I think i can beat it however. #speaker:Riley #portrait:riley #layout:left
- 1: Sorry to say, but that was kind of lame. #speaker:Riley #portrait:riley #layout:left
- 2: Interesting. Reminds me of something like this. #speaker:Riley #portrait:riley #layout:left
- 3: Haha. nice one. But just you wait till you see this one #speaker:Riley #portrait:riley #layout:left
- 4: Interesting. #speaker:Riley #portrait:riley #layout:left
}

-> END

