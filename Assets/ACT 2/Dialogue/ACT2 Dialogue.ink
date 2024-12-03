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
    -> stitch4

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
        -> stitch4

    ** Not really. #speaker:Player #portrait:player #layout:right  
        What about you? Got anything cool to share? #speaker:Player #portrait:player #layout:right  
        Of course! I’ve got a ton of interesting stuff. #speaker:Riley #portrait:riley #layout:left  
        Here, let me find something. #speaker:Riley #portrait:riley #layout:left  
        -> stitch4

* Maybe. What kind of stuff are you into? #speaker:Player #portrait:player #layout:right  
    Oh, a little bit of everything—funny memes, interesting articles, deep stuff. #speaker:Riley #portrait:riley #layout:left  
    If you’re down, I can send you something cool! #speaker:Riley #portrait:riley #layout:left  

    ** Sure, send something over. #speaker:Player #portrait:player #layout:right  
        ~ willToShare = true  
        Alright, let me grab something for you. #speaker:Riley #portrait:riley #layout:left  
        -> stitch4  

    ** I’ll see if I have something to share too. #speaker:Player #portrait:player #layout:right  
        ~ willToShare = true  
        Great! Looking forward to it. #speaker:Riley #portrait:riley #layout:left  
        -> stitch3  

                

= stitch3
VAR sharedRileyPost = 0

//0-2 Riley means it. 3-4 Riley is sarcastic or "plays along"
{sharedRileyPost:
- 0: Haha. Nice one. I think i can beat it however. #speaker:Riley #portrait:riley #layout:left
- 1: Sorry to say, but that was kind of lame. #speaker:Riley #portrait:riley #layout:left
- 2: Interesting. Reminds me of something like this. #speaker:Riley #portrait:riley #layout:left
- 3: haha. nice one. But just you wait till you see this one #speaker:Riley #portrait:riley #layout:left
- 4: interesting. #speaker:Riley #portrait:riley #layout:left
}

-> stitch4

= stitch4
VAR shareTopic = 1

/*
4. Rileys Share
(Riley either brings up a theme based on what the player shared or based on the feed interaction score. Riley will choose one of the three: anxiety, grind culture, or body image.)
*/

{willToShare == true:
    Here, check out this one. #speaker:Riley #portrait:riley #layout:left
    }

(Riley shares a post)

{shareTopic:
- 0: ->stitch5
- 1: ->stitch6
- 2: ->stitch7
}
    
// Anxiety
= stitch5
* Did that happen recently? #speaker:Player #portrait:player #layout:right
    Yes. I swear, the world is slowly falling apart. #speaker:Riley #portrait:riley #layout:left
    ** [Do you think there is anything we can do about it anymore?] #speaker:Player #portrait:player #layout:right
        Do you think there is anything we can do about it anymore?.#speaker:Player #portrait:player #layout:right
        Like, is it too late for us to do anything about it?#speaker:Player #portrait:player #layout:right
        
        Probably. With the way things are going it wouldn’t surprise me. #speaker:Riley #portrait:riley #layout:left
        *** I don't believe that. i don't want to believe that. #speaker:Player #portrait:player #layout:right
        ->stitch8
        *** There must be something to do about it. What if. #speaker:Player #portrait:player #layout:right
        ->stitch8

    **[I don’t think you need to look at it that way.] #speaker:Player #portrait:player #layout:right
        I don’t think you need to look at it that way. #speaker:Player #portrait:player #layout:right
        Yes, shit happens, but not something that you should worry about too much. #speaker:Player #portrait:player #layout:right
        
        You're saying I shouldn't care about the world that I live in? #speaker:Riley #portrait:riley #layout:left
        *** I’m saying that there is nothing to gain from worrying about these things. #speaker:Player #portrait:player #layout:right
        -> stitch9
        *** No, no, of course you should care. Just don’t forget yourself in the process. #speaker:Player #portrait:player #layout:right
        -> stitch9

* That doesn’t sound right. Must be fake. #speaker:Player #portrait:player #layout:right
    I swear. You can trust this one. Things are really turning for the worse. #speaker:Riley #portrait:riley #layout:left
    
    ** I don't believe that. i don't want to believe that. #speaker:Player #portrait:player #layout:right
        ->stitch8
        
    ** [Do you think there is anything we can do about it anymore?] #speaker:Player #portrait:player #layout:right
        Do you think there is anything we can do about it anymore?. #speaker:Player #portrait:player #layout:right
        Like, is it too late for us to do anything about it? #speaker:Player #portrait:player #layout:right
        
        Probably. With the way things are going it wouldn’t surprise me. #speaker:Riley #portrait:riley #layout:left
        *** I don't believe that. i don't want to believe that. #speaker:Player #portrait:player #layout:right
        ->stitch8
        *** There must be something to do about it. What if. #speaker:Player #portrait:player #layout:right
        ->stitch8

    **[I don’t think you need to look at it that way.]  #speaker:Player #portrait:player #layout:right
        I don’t think you need to look at it that way.  #speaker:Player #portrait:player #layout:right
        Yes, shit happens, but not something that you should worry about too much. #speaker:Player #portrait:player #layout:right
        
        You're saying I shouldn't care about the world that I live in? #speaker:Riley #portrait:riley #layout:left
        *** I’m saying that there is nothing to gain from worrying about these things. #speaker:Player #portrait:player #layout:right 
        -> stitch9
        *** No, no, of course you should care. Just don’t forget yourself in the process #speaker:Player #portrait:player #layout:right
        -> stitch9

// Grind Culture
= stitch6
* Damn! That hits hard. #speaker:Player #portrait:player #layout:right
    I know right! Really a wake up call to start getting shit done. #speaker:Riley #portrait:riley #layout:left
    ** Suddenly I feel behind on everything. #speaker:Player #portrait:player #layout:right
        I get the same feeling sometimes. #speaker:Riley #portrait:riley #layout:left
        But as long as you focus on being productive then that feeling will begin to go away. #speaker:Riley #portrait:riley #layout:left
        ->stitch8
    ** I feel kind of energized after seeing that. #speaker:Player #portrait:player #layout:right
        Like, I suddenly have a lot to do #speaker:Player #portrait:player #layout:right
        Same. It’s very motivational. #speaker:Riley #portrait:riley #layout:left
        ->stitch8
* Hmmm… That all just sounds way too over exaggerated #speaker:Player #portrait:player #layout:right
    It's just how the world works. #speaker:Riley #portrait:riley #layout:left
    If you want to keep up with everyone else. #speaker:Riley #portrait:riley #layout:left
    You’ve gotta push hard. #speaker:Riley #portrait:riley #layout:left
    ** Agree. Gotta keep grinding. #speaker:Player #portrait:player #layout:right
        Gotta keep grinding. #speaker:Riley #portrait:riley #layout:left
        ->stitch8
    ** But you should also have time to live. #speaker:Player #portrait:player #layout:right
        The continuous grind will just burn you out. #speaker:Player #portrait:player #layout:right
        With that mindset you are not getting very far. #speaker:Riley #portrait:riley #layout:left
        *** We’ll see. #speaker:Player #portrait:player #layout:right
            Thanks for the talk. #speaker:Player #portrait:player #layout:right
        ->stitch9
        *** Or maybe I'll get further. #speaker:Player #portrait:player #layout:right
            Thanks for the talk. #speaker:Player #portrait:player #layout:right
        ->stitch9


* Is that the type of content you usually get? #speaker:Player #portrait:player #layout:right
    Yeah. Just reminds one to keep pushing forward. #speaker:Riley #portrait:riley #layout:left
    That in the end you will be rewarded for your hard work. #speaker:Riley #portrait:riley #layout:left
    ** Agree. Gotta keep grinding. #speaker:Player #portrait:player #layout:right
        Gotta keep grinding. #speaker:Riley #portrait:riley #layout:left
        ->stitch8
    ** But you should also have time to live. #speaker:Player #portrait:player #layout:right
        The continuous grind will just burn you out. #speaker:Player #portrait:player #layout:right
        With that mindset you are not getting very far. #speaker:Riley #portrait:riley #layout:left
        *** We’ll see. #speaker:Player #portrait:player #layout:right
        ->stitch9
        *** Or maybe I'll get further. #speaker:Player #portrait:player #layout:right
        ->stitch9

// Body Image
= stitch7
* Literally the dream to look like that. #speaker:Player #portrait:player #layout:right
    Yep. #speaker:Riley #portrait:riley #layout:left
    Sometimes it feels unfair that some people naturally look this good. #speaker:Riley #portrait:riley #layout:left
    ** I get what you mean. #speaker:Player #portrait:player #layout:right
        -> stitch8 
        
    ** Idk. #speaker:Player #portrait:player #layout:right
        Some of it might also come from them eating healthy and exercising a lot. #speaker:Player #portrait:player #layout:right
        
        And that is fair enough. #speaker:Riley #portrait:riley #layout:left
        But there are also some who don't have to put in any effort to look good. #speaker:Riley #portrait:riley #layout:left
        Who are just perfect by default. #speaker:Riley #portrait:riley #layout:left
        Those type of people can just be annoying. #speaker:Riley #portrait:riley #layout:left
        
        *** That we can agree on. #speaker:Player #portrait:player #layout:right
        -> stitch8
        *** I wouldn't think about it all too much. #speaker:Player #portrait:player #layout:right
            Just puts unnecessary pressure on oneself. #speaker:Player #portrait:player #layout:right
            
            Sure. #speaker:Riley #portrait:riley #layout:left
            ->stitch9
        

* Ugh. Clearly someone with validation issues. #speaker:Player #portrait:player #layout:right

    What do you mean? #speaker:Riley #portrait:riley #layout:left
    
    ** They clearly only post these kinds of things to get attention. #speaker:Player #portrait:player #layout:right
        I bet you they don’t really look like that. #speaker:Player #portrait:player #layout:right
        
        Of course they don't, but don't you still get the feeling that you could look like that? #speaker:Riley #portrait:riley #layout:left
        Like, its achievable. #speaker:Riley #portrait:riley #layout:left
        
        *** Not really, sorry. #speaker:Player #portrait:player #layout:right
            Lucky you. #speaker:Riley #portrait:riley #layout:left
            -> stitch9
        *** I guess i feel it a little bit, but. #speaker:Player #portrait:player #layout:right
        -> stitch8
        
        
    
    ** Idk, just doesn’t feel real. #speaker:Player #portrait:player #layout:right
    
        Of course its not real, but don't you still get the feeling that you could look like that? #speaker:Riley #portrait:riley #layout:left
        Like, its achievable. #speaker:Riley #portrait:riley #layout:left
        *** Not really, sorry. #speaker:Player #portrait:player #layout:right
            Lucky you. 
            -> stitch9
        *** I guess i feel it a little bit, but. #speaker:Player #portrait:player #layout:right
        -> stitch8
    
* Is that the type of content you usually get. #speaker:Player #portrait:player #layout:right
    More or less. #speaker:Riley #portrait:riley #layout:left
    It's just crazy that some people naturally look this good. #speaker:Riley #portrait:riley #layout:left
    
    ** Eh, I wouldn't think about it too much. #speaker:Player #portrait:player #layout:right
        Most people don't look like that, so no need to put unrealistic expectations on yourself. #speaker:Player #portrait:player #layout:right
        ->stitch9
        
    ** I get what you mean. #speaker:Player #portrait:player #layout:right
        Like, it can sometimes feel unfair how little effort some people have to do to look good. #speaker:Player #portrait:player #layout:right
        ->stitch8


// Connected with Riley
= stitch8
Oh, Sorry. My mom is calling for dinner. I'll talk to you later after i've eaten. #speaker:Player #portrait:player #layout:right

Of course. I’ll talk to you later. #speaker:Riley #portrait:riley #layout:left

/*
5. Act End - fade to black

System Message:
After dinner you and Riley continue your conversation about (insert topic name). Riley shares more similar posts with you and you start to see the same type of posts on your feed that you start sharing. 

After a longer conversation, you both have to go to bed, but you agreed to meet on YapChat! again tomorrow.

End of Act 2
*/
->END

// Disconnected with Riley
= stitch9
Thanks for the talk. #speaker:Riley #portrait:riley #layout:left

/*
5. Act End - fade to black

System Message:
After Riley's last message, mom calls you downstairs for dinner. When you got back to your computer Riley had gone offline. You scrolled the feed for a short while, before turning off your computer, and going to bed.
End of Act 2
*/
-> END