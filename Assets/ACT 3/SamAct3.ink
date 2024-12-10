INCLUDE GlobalVariables.ink

-> SamAct3

=== SamAct3 ===

// Intro
=stitch1
VAR timerEnabled = false

{RileyConnected == true:
    // Act 2 ended with Riley connection
    Hey. #speaker:Sam #portrait:sam #layout:left
    
    Look, I know it’s been a while since we talked. #speaker:Sam #portrait:sam #layout:left
    
    I haven’t been online much, and I guess you probably noticed that. #speaker:Sam #portrait:sam #layout:left
    
    It’s not that I didn’t want to. #speaker:Sam #portrait:sam #layout:left
    
    I just needed a break from everything. #speaker:Sam #portrait:sam #layout:left
    
    Things are just a mess right now, and I don’t know what to say. #speaker:Sam #portrait:sam #layout:left
    
    *   Of course. What’s going on? #speaker:Player #portrait:player #layout:right
        ~ reality_awareness += 2
        -> stitch2
    *   Just say it. What's happening? #speaker:Player #portrait:player #layout:right
        -> stitch2
    *   Ummmm, Ok. Whatever, I don't really care. #speaker:Player #portrait:player #layout:right
        ~ reality_awareness -= 2
        -> stitch3
}

// Supportive at first
= stitch2
// Friends with Riley
It's just that for the past few days thing have kind of gone to shit for me and my family. #speaker:Sam #portrait:sam #layout:left
Last time after we spoke on here, we got a call from the hospital. #speaker:Sam #portrait:sam #layout:left
They told us that dad had been sent to the emergency room, due to an accident. #speaker:Sam #portrait:sam #layout:left
He is fine now, but we really didn't think he was gonna make it, when they initially called.  #speaker:Sam #portrait:sam #layout:left
I'm still kind of on edge from this whole experience and could really use a friend right now. #speaker:Sam #portrait:sam #layout:left
~ timerEnabled = true
* Im so sorry, I am always here for you Sam. #speaker:Player #portrait:player #layout:right
    ->listeningstitch
* You can tell me anything. What happened? #speaker:Player #portrait:player #layout:right
    ->listeningstitch2
* LoL, grow up Sam. I can't always be there for you, you know. #speaker:Player #portrait:player #layout:right
    I just want you to listen. #speaker:Sam #portrait:sam #layout:left
    That is all I am asking of you. #speaker:Sam #portrait:sam #layout:left
    ** I did not mean it like that, I am always there for you. #speaker:Player #portrait:player #layout:right
        -> listeningstitch
    ** I really don't have the time for this. #speaker:Player #portrait:player #layout:right
        ->stitch4

=listeningstitch
Thanks, it means a lot. #speaker:Sam #portrait:sam #layout:left
He was caught in a serious car accident. #speaker:Sam #portrait:sam #layout:left
Getting the phone call, thinking I had lost him... #speaker:Sam #portrait:sam #layout:left
It's just hard you know? #speaker:Sam #portrait:sam #layout:left
* I don't know what to say. I am so sorry you had to go through that. #speaker:Player #portrait:player #layout:right
    Thanks. #speaker:Sam #portrait:sam #layout:left
    He is so important to me #speaker:Sam #portrait:sam #layout:left
    and the thought of loosing him is just too much handle #speaker:Sam #portrait:sam #layout:left
    ** That sounds awful, but at least he's okay now. Try to focus on that. #speaker:Player #portrait:player #layout:right
        ->listeningstitch2
    ** Hey, even if he died you would still have your mom. Don't think about it too much. #speaker:Player #portrait:player #layout:right
        ->stitch4
* That must have been so heartbreaking and scary. #speaker:Player #portrait:player #layout:right
    I have never been more scared #speaker:Sam #portrait:sam #layout:left
    He means too much for me to lose him already #speaker:Sam #portrait:sam #layout:left
    There is so much more I want to do with him. #speaker:Sam #portrait:sam #layout:left
    ** I get that. Don't know what I would do if I lost my dad. #speaker:Player #portrait:player #layout:right
        ->listeningstitch2
    ** Hey you can still do all that. Dad or no dad. Doesn't matter really. #speaker:Player #portrait:player #layout:right
        ->stitch4
* That's so crazy. What then? #speaker:Player #portrait:player #layout:right
    I would not call it crazy. #speaker:Sam #portrait:sam #layout:left
    It was so scary. #speaker:Sam #portrait:sam #layout:left
    I don't know how I would have dealt with it if I lost him... #speaker:Sam #portrait:sam #layout:left
    ** Sorry didn't meant it like that. I would have been scared too. #speaker:Player #portrait:player #layout:right
        ->listeningstitch2
    ** It would make for a crazy good post on YapChat. It would create a lot of reactions. #speaker:Player #portrait:player #layout:right
        wtf #speaker:Sam #portrait:sam #layout:left
        that is my dad's life you are talking about #speaker:Sam #portrait:sam #layout:left
        not some something to make jokes about #speaker:Sam #portrait:sam #layout:left
        ->stitch4

=listeningstitch2
Its just. I feel like I should have been there for him. #speaker:Sam #portrait:sam #layout:left
Done something. #speaker:Sam #portrait:sam #layout:left
I know it's stupid, but I just... #speaker:Sam #portrait:sam #layout:left
Feel helpless. #speaker:Sam #portrait:sam #layout:left
* It's not stupid. You're going through a lot right now. Be kind to yourself. #speaker:Player #portrait:player #layout:right
    Yeah.. #speaker:Sam #portrait:sam #layout:left
    You are right. I shouldn't blame myself. #speaker:Sam #portrait:sam #layout:left
    Its still just hard seeing him in the state he is in. #speaker:Sam #portrait:sam #layout:left
    Hooked up to machines, in so much pain... #speaker:Sam #portrait:sam #layout:left
    ** Hey. He will pull through and be back to normal in no time. You just need to be strong for him. #speaker:Player #portrait:player #layout:right
        You are right. I know. #speaker:Sam #portrait:sam #layout:left
        Its good to hear this comming from you. #speaker:Sam #portrait:sam #layout:left
        ->goodendstitch
    ** Your dad is the toughest guy I know. Nothing he can't beat. #speaker:Player #portrait:player #layout:right
        He really is. #speaker:Sam #portrait:sam #layout:left
        I could not wish for a better dad. #speaker:Sam #portrait:sam #layout:left
        ->goodendstitch
* You did what you could Sam. Sometimes things are out of your control. #speaker:Player #portrait:player #layout:right
    Yeah. #speaker:Sam #portrait:sam #layout:left
    Some things you can't control #speaker:Sam #portrait:sam #layout:left
    Its just so unfair... #speaker:Sam #portrait:sam #layout:left
    Why did this have to happen to him? #speaker:Sam #portrait:sam #layout:left
    ** Life sometimes just isn't fair. He will pull through and be back to normal soon. #speaker:Player #portrait:player #layout:right
        Yeah I know. #speaker:Sam #portrait:sam #layout:left
        Thanks, it good to hear from you. #speaker:Sam #portrait:sam #layout:left
        ->goodendstitch
    ** Yeah it unfair. But he is strong he will pull through. #speaker:Player #portrait:player #layout:right
        He is the strongest I know. #speaker:Sam #portrait:sam #layout:left
        He always pulls through. #speaker:Sam #portrait:sam #layout:left
        ->goodendstitch
* You should have done more. Why didn't you? #speaker:Player #portrait:player #layout:right
    I.. tried... #speaker:Sam #portrait:sam #layout:left
    I thought you would support me? #speaker:Sam #portrait:sam #layout:left
    ** I just mean that you shouldn't give up. Be strong and be there for him. #speaker:Player #portrait:player #layout:right
        Oh. I thought you meant something different. #speaker:Sam #portrait:sam #layout:left
        Thanks, I will always be by him. #speaker:Sam #portrait:sam #layout:left
        I won't give up on him. #speaker:Sam #portrait:sam #layout:left
        ->goodendstitch
    ** Come on dude. If anyone is to blame its you. #speaker:Player #portrait:player #layout:right
        I wasn't even there? #speaker:Sam #portrait:sam #layout:left
        How are you so out of touch? #speaker:Sam #portrait:sam #layout:left
        ->stitch4

=goodendstitch
Hey. Thank you for listening to me. #speaker:Sam #portrait:sam #layout:left
You are such a good friend. #speaker:Sam #portrait:sam #layout:left
This really helped. I want you to know that. #speaker:Sam #portrait:sam #layout:left
* I just hope your dad gets better soon. #speaker:Player #portrait:player #layout:right
    Same here. #speaker:Sam #portrait:sam #layout:left
    Will keep you updated. #speaker:Sam #portrait:sam #layout:left
    ->END
* Remember to take care of yourself. #speaker:Player #portrait:player #layout:right
    Will do. #speaker:Sam #portrait:sam #layout:left
    Will keep you updated. #speaker:Sam #portrait:sam #layout:left
    See you later :) #speaker:Sam #portrait:sam #layout:left
    ->END

// Dismissive
=stitch3
{RileyConnected == true:
    Don't you care at all what has happened to me? #speaker:Sam #portrait:sam #layout:left
    
    * Of course i do. What going on? #speaker:Player #portrait:player #layout:right
        ~ reality_awareness += 1
        Well. #speaker:Sam #portrait:sam #layout:left
        ->stitch2
    * Sure i do, but I'm also kind of in the middle of something. #speaker:Player #portrait:player #layout:right
        ~ reality_awareness -= 1
        Can't you pls put that on hold and just listen? #speaker:Sam #portrait:sam #layout:left
            ** Ok. What is going on? #speaker:Player #portrait:player #layout:right
             ~ reality_awareness += 1
            ->stitch2
            ** Sorry. Can't do that. #speaker:Player #portrait:player #layout:right
             ~ reality_awareness -= 2
             If that is truly how you feel, then I guess I'll just talk to someone who actually cares. #speaker:Sam #portrait:sam #layout:left
             And to think I thought you were a friend that I could count on. #speaker:Sam #portrait:sam #layout:left
             ->stitch4
             
            
        
    * Not really. #speaker:Player #portrait:player #layout:right
        ~ reality_awareness -= 5
        Since when have you become such an ass? #speaker:Sam #portrait:sam #layout:left
        I'm trying to reach out to someone for help and you just ignore me completly. #speaker:Sam #portrait:sam #layout:left
        
        ** That's right. #speaker:Player #portrait:player #layout:right
        ~ reality_awareness -= 2
            Well f*** you then. #speaker:Sam #portrait:sam #layout:left
            I hope you die alone. #speaker:Sam #portrait:sam #layout:left
            ->END
        ** I'm sorry. I was being rude. What is going on? #speaker:Player #portrait:player #layout:right
        ~ reality_awareness += 1
            I'm not sure I want to tell you if you're gonna act that way. #speaker:Sam #portrait:sam #layout:left
            
            *** I'm sorry. I swear I'm gonna listen. #speaker:Player #portrait:player #layout:right
            ~ reality_awareness += 1
                Ok then. #speaker:Sam #portrait:sam #layout:left
                ->stitch2
            *** Then don't. I don't care. #speaker:Player #portrait:player #layout:right
                ~ reality_awareness -= 2
                If that is truly how you feel, then I guess I'll just talk to someone who actually cares. #speaker:Sam #portrait:sam #layout:left
                And to think I thought you were my friend. #speaker:Sam #portrait:sam #layout:left
                ->stitch4
}

=stitch4
What happened to you? #speaker:Sam #portrait:sam #layout:left
you have really changed since joining YapChat. #speaker:Sam #portrait:sam #layout:left
I don't even recognize my friend anymore. #speaker:Sam #portrait:sam #layout:left
* I am sorry, I didn't mean it like that. I am still willing to listen. #speaker:Player #portrait:player #layout:right
    Okay. #speaker:Sam #portrait:sam #layout:left
    Pls. I just want my old friend back. #speaker:Sam #portrait:sam #layout:left
    ** A lot has been going on since last time we spoke. I am still your best friend Sam, nothing will change that. #speaker:Player #portrait:player #layout:right
        Thanks. #speaker:Sam #portrait:sam #layout:left
        You have always been there for me. #speaker:Sam #portrait:sam #layout:left
        ->listeningstitch2
    ** Nah, I did mean it like that. Jokes on you. #speaker:Player #portrait:player #layout:right
        You are such an ass. #speaker:Sam #portrait:sam #layout:left
        I better just leave. #speaker:Sam #portrait:sam #layout:left
        Goodbye. #speaker:Sam #portrait:sam #layout:left
        ->END
* Hey I haven't changed, you just lost your humor. #speaker:Player #portrait:player #layout:right
    and you just lost a friend #speaker:Sam #portrait:sam #layout:left
    Goodbye. #speaker:Sam #portrait:sam #layout:left
    ->END
* Don't put this on me. You are the one bringing down the atmosphere. #speaker:Player #portrait:player #layout:right
    You are actually so out of touch. #speaker:Sam #portrait:sam #layout:left
    I can't take anymore of this from you. #speaker:Sam #portrait:sam #layout:left
    Goodbye. #speaker:Sam #portrait:sam #layout:left
    ->END




