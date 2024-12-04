INCLUDE GlobalVariables.ink

-> SamAct3

=== SamAct3 ===

// Intro
=stitch1

{RileyConnected == true:
    // Act 2 ended with Riley connection
    // Sam writes after talking with Riley in act 3
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
    *   Ummmm, Ok.  #speaker:Player #portrait:player #layout:right
        ~ reality_awareness -= 2
        -> stitch3
}
{RileyConnected == false:
    // Act 2 ended without Riley connection
    // Sam writes before talking with Riley in act 3
    Hey. #speaker:Sam #portrait:sam #layout:left
    
    I know I’ve been out of touch. #speaker:Sam #portrait:sam #layout:left
    
    And I don’t blame you if you’re confused about it. #speaker:Sam #portrait:sam #layout:left
    
    Honestly, I’m just trying to figure things out for myself. #speaker:Sam #portrait:sam #layout:left
    
    I don’t have a good excuse.  #speaker:Sam #portrait:sam #layout:left
    
    Things are just a mess right now, and I don’t know what to say. #speaker:Sam #portrait:sam #layout:left

    Can we meet up? Or at least talk properly? #speaker:Sam #portrait:sam #layout:left
    
    *   What happened, Sam? You just disapeared all of a sudden? #speaker:Player #portrait:player #layout:right
        ~ reality_awareness += 2
        -> stitch2
        
    *   What’s going on? #speaker:Player #portrait:player #layout:right
        ~ reality_awareness += 1
        -> stitch2
    
    *   I’m kind of busy right now. #speaker:Player #portrait:player #layout:right
        ~ reality_awareness -= 2
        -> stitch3
}

// Supportive at first
= stitch2
// Friends with Riley
{RileyConnected == true:
It's just that for the past few days thing have kind of gone to shit for me and my family. #speaker:Sam #portrait:sam #layout:left

Last time after we spoke on here, we got a call from the hospital. #speaker:Sam #portrait:sam #layout:left

They told us that dad had been sent to the emergency room, due to an accident at work. #speaker:Sam #portrait:sam #layout:left

He is fine now, but we really didn't think he was gonna make it, when they initially called.  #speaker:Sam #portrait:sam #layout:left

I'm still kind of on edge from this whole experience and could really use a friend right now. #speaker:Sam #portrait:sam #layout:left

Could we meet up somewhere? #speaker:Sam #portrait:sam #layout:left

* Of course. Any particular place you had in mind? #speaker:Player #portrait:player #layout:right
    ~ reality_awareness += 2
        The park across the train station. #speaker:Sam #portrait:sam #layout:left
        Maybe we could meet each other there within the next 15 minutes? #speaker:Sam #portrait:sam #layout:left
            ** Sure, i'll see you then. #speaker:Player #portrait:player #layout:right
            ~ reality_awareness += 2
            ~ MeetSam = true
                Great. See ya. #speaker:Sam #portrait:sam #layout:left
            ->END
            ** Could we meet later today? It's just that I'm talking with someone else on here right now. #speaker:Player #portrait:player #layout:right
               ~ reality_awareness -= 2 
                And who is that? #speaker:Sam #portrait:sam #layout:left
                
                *** Someone called Riley I met on here a few days ago. #speaker:Player #portrait:player #layout:right
                    
                    Can't you just tell them that something has come up and you have to go? #speaker:Sam #portrait:sam #layout:left
                    
                        **** Sure i can do that. Just a sec. #speaker:Player #portrait:player #layout:right
                            Ok. #speaker:Sam #portrait:sam #layout:left
                            ~ reality_awareness += 2
                            ~ MeetSam = true
                            {SamWait:
                            - 5: ->stitch4
                            -10: ->stitch5
                            -15: ->stitch6
                            }
                            
                            
                        **** Can't we just meet up later? #speaker:Player #portrait:player #layout:right
                            ~ reality_awareness -= 2
                            I literally just explained my situation to you. #speaker:Sam #portrait:sam #layout:left
                            How can you do this to me? #speaker:Sam #portrait:sam #layout:left
                            
                            ***** Your right. I'm sorry. I'll tell Riley I have to go. #speaker:Player #portrait:player #layout:right
                                ~ reality_awareness += 2
                                Ok. 
                                ~ MeetSam = true
                                {SamWait:
                                - 5: ->stitch4
                                -10: ->stitch5
                                -15: ->stitch6
                                }
                            
                            ***** Because I was talking to them first. We are propably done in like an hour so, so can't you just wait? #speaker:Player #portrait:player #layout:right
                                ~ reality_awareness -= 2 
                                No. #speaker:Sam #portrait:sam #layout:left
                                I clearly explained that I needed a friend right now. #speaker:Sam #portrait:sam #layout:left
                                
                                ****** Come on Sam. I am your friend. Just wait. I'll tell Riley i have to go. Then I'll meet up with you. #speaker:Player #portrait:player #layout:right
                                    ~ reality_awareness += 2
                                    Ok. Just be quick. #speaker:Sam #portrait:sam #layout:left
                                     ~ MeetSam = true
                                    {SamWait:
                                    - 5: ->stitch4
                                    -10: ->stitch5
                                    -15: ->stitch6
                                    }
                                    
                                ****** But why can't you just wait? Why does it have to be so soon? #speaker:Player #portrait:player #layout:right
                                    ~ reality_awareness -= 2 
                                    It just does. #speaker:Sam #portrait:sam #layout:left
                                    The fact that you don't understand that, just proves that you aren't the friend I thought you were. #speaker:Sam #portrait:sam #layout:left
                                    Clearly Riley is more important to you than i am, so have fun with your new friend.  #speaker:Sam #portrait:sam #layout:left
                                    Don't bother contacting me ever again. #speaker:Sam #portrait:sam #layout:left
                                    ->END
                {ShutUpRiley == true:                    
                *** Never mind. I'll be there as soon as I can. #speaker:Player #portrait:player #layout:right
                    ~ reality_awareness += 2
                    ~ MeetSam = true
                    Nice. See ya. #speaker:Sam #portrait:sam #layout:left
                        ->END
                }
 
            
* Can't we just talk about it here? What difference does it make if we meet up? #speaker:Player #portrait:player #layout:right
    ~ reality_awareness -= 2
    What difference does it make? #speaker:Sam #portrait:sam #layout:left
    Do you care so little about my situation that you think it can be dealt with through a f***ing chat room? #speaker:Sam #portrait:sam #layout:left
    ** [Don't you just want someone to talk to? I'm here. I listen.] #speaker:Player #portrait:player #layout:right
        Don't you just want someone to talk to? #speaker:Player #portrait:player #layout:right
        I'm here. #speaker:Player #portrait:player #layout:right
        I listen. #speaker:Player #portrait:player #layout:right
        Why bother trying to meet up somewhere, when we can discuss the issue right here, right now? #speaker:Player #portrait:player #layout:right
        ~ reality_awareness -= 2
        I want someone to BE THERE FOR ME! #speaker:Sam #portrait:sam #layout:left
        If you really can't be bothered to meet up, then you clearly aren't the friend I thought you were.  #speaker:Sam #portrait:sam #layout:left
        *** Your right. I'm sorry. Don't know what i was thinking. Where would you like to meet? #speaker:Player #portrait:player #layout:right
            ~reality_awareness += 2
            Do you actually want to come? #speaker:Sam #portrait:sam #layout:left
            Do you actually care? #speaker:Sam #portrait:sam #layout:left
            
            **** I do. I swear. Where should we meet? #speaker:Player #portrait:player #layout:right
            ~reality_awareness += 2
                Ok. #speaker:Sam #portrait:sam #layout:left
                Just meet me by the park across the train station in 15 minutes. #speaker:Sam #portrait:sam #layout:left
                Can you do that? #speaker:Sam #portrait:sam #layout:left
                ***** Yes, i'll be there. See ya in 15. #speaker:Player #portrait:player #layout:right
                    See ya. #speaker:Sam #portrait:sam #layout:left
                    ~reality_awareness += 2
                    ~ MeetSam = true
                    ->END
        
        *** I'm here for you. But i just don't see how things will be different if we meet up. #speaker:Player #portrait:player #layout:right
            ~ reality_awareness -= 2
            Well then you aren't really here for me. Are you? #speaker:Sam #portrait:sam #layout:left
            I thought you were my friend. #speaker:Sam #portrait:sam #layout:left
            Don't contact me ever again. #speaker:Sam #portrait:sam #layout:left
            -> END
            
                
    ** Of course not. Sorry. Don't know what i was thinking. Where should we meet? #speaker:Player #portrait:player #layout:right
        ~ reality_awareness += 2
        It's ok. #speaker:Sam #portrait:sam #layout:left
        Let's just meet by the park across the train station. #speaker:Sam #portrait:sam #layout:left
        Could you be there within 15 minutes or so? #speaker:Sam #portrait:sam #layout:left
        
        *** Sure, i'll be there. #speaker:Player #portrait:player #layout:right
        ~ reality_awareness += 2
            Thank you. See you in a bit. #speaker:Sam #portrait:sam #layout:left
            ~ MeetSam = true
            ->END
        
        *** Maybe. I just have to deal with something before i can go. #speaker:Player #portrait:player #layout:right
               ~ reality_awareness -= 2 
                Really? #speaker:Sam #portrait:sam #layout:left
                And what is that? #speaker:Sam #portrait:sam #layout:left
                
                **** Someone on here just keeps sending me posts and messages me. Just have to deal with it. #speaker:Player #portrait:player #layout:right
                    
                    Why don't you just ignore them and come over. #speaker:Sam #portrait:sam #layout:left
                        ***** Your right. I'll be there as soon as i can. #speaker:Player #portrait:player #layout:right
                         ~ reality_awareness += 2
                         ~ MeetSam = true
                            Nice. See ya. #speaker:Sam #portrait:sam #layout:left
                            ->END
                            
                        ***** It won't take long just wait a bit. #speaker:Player #portrait:player #layout:right
                            ~ reality_awareness -= 2
                            I literally just explained my situation to you. #speaker:Sam #portrait:sam #layout:left
                            How can you do this to me? #speaker:Sam #portrait:sam #layout:left
                            
                            ****** Your right. I'm sorry. I'll be there as soon as i can. #speaker:Player #portrait:player #layout:right
                             ~ reality_awareness += 2
                            Ok. See ya. #speaker:Sam #portrait:sam #layout:left
                            ~ MeetSam = true
                            ->END
                            
                            ****** It won't take more than 5 minutes more. Pls. Just wait. #speaker:Player #portrait:player #layout:right
                            ~ reality_awareness -= 2
                                No. #speaker:Sam #portrait:sam #layout:left
                                I clearly explained that i needed a friend right now. #speaker:Sam #portrait:sam #layout:left
                                I thought i could trust you. #speaker:Sam #portrait:sam #layout:left
                                Clearly i was wrong. #speaker:Sam #portrait:sam #layout:left
                                Don't bother coming. #speaker:Sam #portrait:sam #layout:left
                                And don't try to contact me. #speaker:Sam #portrait:sam #layout:left
                                ->END
                {ShutUpRiley == true:               
                **** Never mind. I'll be there as soon as I can. #speaker:Player #portrait:player #layout:right
                    ~ reality_awareness += 2
                    Nice. See ya. #speaker:Sam #portrait:sam #layout:left
                    ~ MeetSam = true
                        ->END 
                }
}


// Not friends with Riley
{RileyConnected == false:
It's just that for the past few days thing have kind of gone to shit for me and my family. #speaker:Sam #portrait:sam #layout:left

Last time after we spoke on here, we got a call from the hospital. #speaker:Sam #portrait:sam #layout:left

They told us that dad had been sent to the emergency room, due to an accident at work. #speaker:Sam #portrait:sam #layout:left

He is fine now, but we really didn't think he was gonna make it, when they initially called. #speaker:Sam #portrait:sam #layout:left

I'm still kind of on edge from this whole experience and could really use a friend right now, so I would appreciate it if we could meet somewhere. #speaker:Sam #portrait:sam #layout:left

* Of course we can meet up. Any particular place you had in mind? #speaker:Player #portrait:player #layout:right
    ~ reality_awareness += 2
        Just meet me at the park across the train station. #speaker:Sam #portrait:sam #layout:left
        Can you be there within 15 minutes? #speaker:Sam #portrait:sam #layout:left
            ** Sure, i'll see you then. #speaker:Player #portrait:player #layout:right
            ~ reality_awareness += 2
                Great. See ya. #speaker:Sam #portrait:sam #layout:left
            ->END
            ** Maybe. I just have to deal with something before i can go. #speaker:Player #portrait:player #layout:right
               ~ reality_awareness -= 2 
                
                And what is that? #speaker:Sam #portrait:sam #layout:left
                
                *** Someone on here just keeps sending me posts and messages me. Just have to deal with it. #speaker:Player #portrait:player #layout:right
                    
                    Why don't you just ignore them and come over. #speaker:Sam #portrait:sam #layout:left
                        **** Your right. I'll be there as soon as i can. #speaker:Player #portrait:player #layout:right
                         ~ reality_awareness += 2
                            Nice. See ya. #speaker:Sam #portrait:sam #layout:left
                            ~ MeetSam = true
                            ->END
                            
                        **** It won't take long just wait a bit. #speaker:Player #portrait:player #layout:right
                            ~ reality_awareness -= 2
                            I literally just explained my situation to you. #speaker:Sam #portrait:sam #layout:left
                            How can you do this to me? #speaker:Sam #portrait:sam #layout:left
                            
                            ***** Your right. I'm sorry. I'll be there as soon as i can. #speaker:Player #portrait:player #layout:right
                             ~ reality_awareness += 2
                            Ok. See ya. #speaker:Sam #portrait:sam #layout:left
                            ~ MeetSam = true
                            ->END
                            
                            ***** It won't take more than 5 minutes more. Pls. Just wait. #speaker:Player #portrait:player #layout:right
                                ~ reality_awareness -= 2
                                No. #speaker:Sam #portrait:sam #layout:left
                                I clearly explained that i needed a friend right now. #speaker:Sam #portrait:sam #layout:left
                                I thought i could trust you. #speaker:Sam #portrait:sam #layout:left
                                Clearly i was wrong. #speaker:Sam #portrait:sam #layout:left
                                Don't bother coming. #speaker:Sam #portrait:sam #layout:left
                                And don't try to contact me ever again. #speaker:Sam #portrait:sam #layout:left
                                ->END
                                
                *** Never mind. I'll be there as soon as I can. #speaker:Player #portrait:player #layout:right
                    ~ reality_awareness += 2
                    Nice. See ya. #speaker:Sam #portrait:sam #layout:left
                    ~ MeetSam = true
                        ->END
 
            
* Can't we just talk about it here? What difference does it make if we meet up? #speaker:Player #portrait:player #layout:right
    ~ reality_awareness -= 2
    What difference does it make? #speaker:Sam #portrait:sam #layout:left
    Do you care so little about my situation that you think it can be dealt with through a f***ing chat room? #speaker:Sam #portrait:sam #layout:left
    ** [Don't you just want someone to talk to? I'm here. I listen.] #speaker:Player #portrait:player #layout:right
        Don't you just want someone to talk to? #speaker:Player #portrait:player #layout:right
        I'm here. #speaker:Player #portrait:player #layout:right
        I listen. #speaker:Player #portrait:player #layout:right
        Why bother trying to meet up somewhere, when we can discuss the issue right here, right now? #speaker:Player #portrait:player #layout:right
        ~ reality_awareness -= 2
        I want someone to BE THERE FOR ME! #speaker:Sam #portrait:sam #layout:left
        If you really can't be bothered to meet up, then you clearly aren't the friend I thought you were. #speaker:Sam #portrait:sam #layout:left
        *** Your right. I'm sorry. Don't know what i was thinking. Where would you like to meet? #speaker:Player #portrait:player #layout:right
            ~reality_awareness += 2
            Do you actually want to come? #speaker:Sam #portrait:sam #layout:left
            Do you actually care? #speaker:Sam #portrait:sam #layout:left
            
            **** I do. I swear. Where should we meet? #speaker:Player #portrait:player #layout:right
            ~reality_awareness += 2
                Ok.  #speaker:Sam #portrait:sam #layout:left
                Just meet me by the park across the train station in 15 minutes. #speaker:Sam #portrait:sam #layout:left
                Can you do that? #speaker:Sam #portrait:sam #layout:left
                ***** Yes, i'll be there. See ya in 15. #speaker:Player #portrait:player #layout:right
                    See ya.#speaker:Sam #portrait:sam #layout:left
                    ~reality_awareness += 2
                    ~ MeetSam = true
                    ->END
        
        *** I'm here for you. But i just don't see how things will be different if we meet up. #speaker:Player #portrait:player #layout:right
            ~ reality_awareness -= 2
            Well then you aren't really here for me are you? #speaker:Sam #portrait:sam #layout:left
            I thought you were my friend. #speaker:Sam #portrait:sam #layout:left
            Don't contact me ever again. #speaker:Sam #portrait:sam #layout:left
            -> END
            
                
    ** Of course not. Sorry. Don't know what i was thinking. Where should we meet? #speaker:Player #portrait:player #layout:right
        ~ reality_awareness += 2
        It's ok. #speaker:Sam #portrait:sam #layout:left
        Let's just meet by the park across the train station. #speaker:Sam #portrait:sam #layout:left
        Could you be there within 15 minutes or so? #speaker:Sam #portrait:sam #layout:left
        
        *** Sure, i'll be there. #speaker:Player #portrait:player #layout:right
        ~ reality_awareness += 2
            Thank you. See you in a bit. #speaker:Sam #portrait:sam #layout:left
            ~ MeetSam = true
            ->END
        
        *** Maybe. I just have to deal with something before i can go. #speaker:Player #portrait:player #layout:right
               ~ reality_awareness -= 2 
                Really? #speaker:Sam #portrait:sam #layout:left
                And what is that? #speaker:Sam #portrait:sam #layout:left
                
                **** Someone on here just keeps messaging me and shares a bunch of posts. Just have to deal with it. #speaker:Player #portrait:player #layout:right
                    
                    Why don't you just ignore them? It clearly can't be more important. #speaker:Sam #portrait:sam #layout:left
                        ***** Your right. I'll be there as soon as i can. #speaker:Player #portrait:player #layout:right
                         ~ reality_awareness += 2
                            Nice. See ya. #speaker:Sam #portrait:sam #layout:left
                            ~ MeetSam = true
                            ->END
                            
                        ***** It won't take long just wait a bit. #speaker:Player #portrait:player #layout:right
                            ~ reality_awareness -= 2
                            I literally just explained my situation to you. #speaker:Sam #portrait:sam #layout:left
                            How can you do this to me? #speaker:Sam #portrait:sam #layout:left
                            
                            ****** Your right. I'm sorry. I'll be there as soon as i can. #speaker:Player #portrait:player #layout:right
                             ~ reality_awareness += 2
                            Ok. See ya. #speaker:Sam #portrait:sam #layout:left
                            ~ MeetSam = true
                            ->END
                            
                            ****** It won't take more than 5 minutes more. Pls. Just wait. #speaker:Player #portrait:player #layout:right
                                ~ reality_awareness -= 2
                                No. #speaker:Sam #portrait:sam #layout:left
                                I clearly explained that i needed a friend right now. #speaker:Sam #portrait:sam #layout:left
                                I thought i could trust you. #speaker:Sam #portrait:sam #layout:left
                                Clearly i was wrong. #speaker:Sam #portrait:sam #layout:left
                                Don't bother coming. #speaker:Sam #portrait:sam #layout:left
                                And don't try to contact me ever again. #speaker:Sam #portrait:sam #layout:left
                                ->END
                                
                **** Nothing never mind. I'll be there as soon as I can. #speaker:Player #portrait:player #layout:right
                    ~ reality_awareness += 2
                    Nice. See ya. #speaker:Sam #portrait:sam #layout:left
                    ~ MeetSam = true
                        ->END 
}


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
             ->END
             
            
        
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
                ->END
}

{RileyConnected == false:
    Can't it wait? I really need someone to talk to right now. #speaker:Sam #portrait:sam #layout:left
    
    * Ok. What is going on? #speaker:Player #portrait:player #layout:right
    ~ reality_awareness += 1
        ->stitch2
    * Sorry, but I'm busy with something else right now. We can talk later. #speaker:Player #portrait:player #layout:right
        So you don't you care about me at all? #speaker:Sam #portrait:sam #layout:left
    
    ** Of course I care about you. Jesus. What is going on? #speaker:Player #portrait:player #layout:right
        ~ reality_awareness += 1
        Are you actually listening? #speaker:Sam #portrait:sam #layout:left
        *** Yes i am. #speaker:Player #portrait:player #layout:right
        ~ reality_awareness += 1
            Ok then. #speaker:Sam #portrait:sam #layout:left
            ->stitch2
        *** I'll try. #speaker:Player #portrait:player #layout:right
        ~ reality_awareness -= 1
            If that is the best you can do then don't bother. #speaker:Sam #portrait:sam #layout:left
            Have fun with whatever it is that is more important than being friend for someone else. #speaker:Sam #portrait:sam #layout:left
            ->END
            
    ** Sure i do, but I'm also kind of in the middle of something. #speaker:Player #portrait:player #layout:right
        ~ reality_awareness -= 1
        Can't you pls put that on hold and just listen? #speaker:Sam #portrait:sam #layout:left
            *** Ok then. What is going on? #speaker:Player #portrait:player #layout:right
             ~ reality_awareness += 1
            ->stitch2
            *** Sorry. Can't do that. #speaker:Player #portrait:player #layout:right
             ~ reality_awareness -= 2
             If that is truly how you feel, then I guess I'll just talk to someone who actually cares. #speaker:Sam #portrait:sam #layout:left
             And to think I thought you were a friend that I could count on. #speaker:Sam #portrait:sam #layout:left
             ->END
}


// Sam patience while waiting
// 5
=stitch4
{ShutUpRiley == false:
    Are you on your way yet? #speaker:Sam #portrait:sam #layout:left
    ~ reality_awareness -= 1
    
    * Not yet. Just wait. I promise it won't take long. #speaker:Player #portrait:player #layout:right
    ~ reality_awareness += 1
    ->DONE
- else: 
    * Yes, I'm On my way now. #speaker:Player #portrait:player #layout:right
    ~ reality_awareness += 2
        Great. See you in a bit. #speaker:Sam #portrait:sam #layout:left
    ->END
}
->DONE

// 10
=stitch5
{ShutUpRiley == false:
    If you don't want to come then just say so instead of wasting my time. #speaker:Sam #portrait:sam #layout:left
    ~ reality_awareness -= 2
    
    * I do want to come, just give me a little more time. #speaker:Player #portrait:player #layout:right
    ~ reality_awareness += 1
    ->DONE
- else: 
    * I do want to come. I'm on my way now. #speaker:Player #portrait:player #layout:right
    ~ reality_awareness += 2
        Great. See you in a bit then. #speaker:Sam #portrait:sam #layout:left
    ->END
}

// 15
=stitch6
{ShutUpRiley == false:
    Alright, i've had it. #speaker:Sam #portrait:sam #layout:left
    Don't bother anymore. #speaker:Sam #portrait:sam #layout:left
    You clearly don't want to help out. #speaker:Sam #portrait:sam #layout:left
    ~ reality_awareness -= 2
    
    + I do want to help. Pls just wait for me. #speaker:Player #portrait:player #layout:right
    ->DONE
- else: 
    * I'm on my way now. Pls just wait for me. #speaker:Player #portrait:player #layout:right
    ~ reality_awareness += 1
    ->END
}

->END




