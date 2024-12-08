INCLUDE GlobalVariables.ink

-> RileyAct3

=== RileyAct3 ===

// Intro
=stitch1
VAR timerEnabled = false
VAR timerDuration = 20.0
VAR rileyIgnored = false

Hey! #speaker:Riley #portrait:riley #layout:left
So… I just saw something. Don’t freak out, but you might want to know. #speaker:Riley #portrait:riley #layout:left
Did you see the post mentioning you on YapChat!? #speaker:Riley #portrait:riley #layout:left

* No, what did they write about me? Is it bad!? #speaker:Player #portrait:player #layout:right
    -> stitch2
* What post? #speaker:Player #portrait:player #layout:right
    -> stitch2
* I don't care, leave me alone. #speaker:Player #portrait:player #layout:right
    Are you sure? #speaker:Riley #portrait:riley #layout:left
    What could be more important? #speaker:Riley #portrait:riley #layout:left
    ** Ok, sure tell me more #speaker:Player #portrait:player #layout:right
        -> stitch2
    ** I REALLY Don't care about your internet drama. Leave me alone. #speaker:Player #portrait:player #layout:right
        -> IgnoreStitch

// Start of timed responses
=stitch2
~ timerEnabled = true

Okay, okay. It’s just… this post about you. #speaker:Riley #portrait:riley #layout:left 
Someone tagged you in this thread, and it’s blowing up. #speaker:Riley #portrait:riley #layout:left
Lots of comments already. #speaker:Riley #portrait:riley #layout:left

* What kind of post? #speaker:Player #portrait:player #layout:right
    I think it is from that group you joined recently. #speaker:Riley #portrait:riley #layout:left
    Like, some of the replies are… not nice. #speaker:Riley #portrait:riley #layout:left
    -> stitch3
* Tagged me? Who? #speaker:Player #portrait:player #layout:right
    Oh, I don't know them, but... #speaker:Riley #portrait:riley #layout:left
    Like, some of the replies are… not nice. #speaker:Riley #portrait:riley #layout:left
    -> stitch3
* I don't care about some random thread #speaker:Player #portrait:player #layout:right
    Oof, you should care. It’s kind of spicy. #speaker:Riley #portrait:riley #layout:left
    Like, some of the replies are… not nice. #speaker:Riley #portrait:riley #layout:left
    -> stitch3

=stitch3
~ timerDuration = 15.0
But hey, maybe it’s no big deal to you. #speaker:Riley #portrait:riley #layout:left
You don’t mind people making assumptions about you, right? #speaker:Riley #portrait:riley #layout:left
* What are they saying!? Just tell me already! #speaker:Player #portrait:player #layout:right
    ->stitch4
* Why would they write about me? I haven't done anything wrong!? #speaker:Player #portrait:player #layout:right
    It seems people don't have that same opinion #speaker:Riley #portrait:riley #layout:left
    ->stitch4
* I don't believe you. Link this post to me then! #speaker:Player #portrait:player #layout:right
    I could link it, but do you really want to see it? #speaker:Riley #portrait:riley #layout:left
    ->stitch4


=stitch4
~ timerDuration = 12.5
They’re talking about how you’re "too cool" for certain people or how you always ghost conversations. #speaker:Riley #portrait:riley #layout:left
Honestly, it sounds like jealousy… or maybe there’s some truth to it? #speaker:Riley #portrait:riley #layout:left
* That's not true! I don't behave like that. #speaker:Player #portrait:player #layout:right
    Hey, I’m just the messenger. #speaker:Riley #portrait:riley #layout:left
    I’m just looking out for you #speaker:Riley #portrait:riley #layout:left
    ->stitch5
* Who said that? I want names! #speaker:Player #portrait:player #layout:right
    I don't know, their accounts are anonyomus #speaker:Riley #portrait:riley #layout:left
    ->stitch5
* They can think what they want I don't care. #speaker:Player #portrait:player #layout:right
    ->stitch5

=stitch5
~ timerDuration = 10
You don’t want them spreading stuff, do you?  #speaker:Riley #portrait:riley #layout:left
If I were you, I’d jump in now before it gets worse. But maybe you’re chill about people dragging your name around? #speaker:Riley #portrait:riley #layout:left
* Fine. I’ll see what’s going on. #speaker:Player #portrait:player #layout:right
    Good. #speaker:Riley #portrait:riley #layout:left
    They should not get away with saying stuff like this about you. #speaker:Riley #portrait:riley #layout:left
    ->EndStitch
* Time to fight fire with fire then. #speaker:Player #portrait:player #layout:right
    Precisely what I would do. #speaker:Riley #portrait:riley #layout:left
    They can't get away saying such lies #speaker:Riley #portrait:riley #layout:left
    ->EndStitch
* Why do you always want me to get involved in this stuff? #speaker:Player #portrait:player #layout:right
    Me? Always? #speaker:Riley #portrait:riley #layout:left
    Nah. #speaker:Riley #portrait:riley #layout:left
    I just think it’s better to handle things before they blow up. #speaker:Riley #portrait:riley #layout:left
    But hey, it’s your life. Just don’t come crying to me if they keep at it. #speaker:Riley #portrait:riley #layout:left
    ** Fine, I will go deal with it. #speaker:Player #portrait:player #layout:right
        Good. #speaker:Riley #portrait:riley #layout:left
        They should not get away with such lies #speaker:Riley #portrait:riley #layout:left
        ->EndStitch
    ** I am not giving them the satisfaction of a response. #speaker:Player #portrait:player #layout:right
        Fine, your choice #speaker:Riley #portrait:riley #layout:left
        ->EndStitch

// Stitch used to end the dialogue when choosing to ignore Riley
=IgnoreStitch
~ rileyIgnored = true
->END

// Normal Ending stitch when no bad option is chosen
=EndStitch
~ rileyIgnored = false
->END