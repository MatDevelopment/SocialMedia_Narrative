INCLUDE GlobalVariables.ink

-> RileyAct3

=== RileyAct3 ===

// Intro
=stitch1
{RileyConnected == true:
// Act 2 ended with Riley connection

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
    Hi again.

    I think we got off on the wrong foot last time we spoke. 

    I know I came on a bit too strongly, but its just that I really want someone to discuss these things wtih.

    * Well, i'm not interested. Bye
        ~reality_awareness += 2
        ~ShutUpRiley = true
        ->END

    * I get that, but i don't think you are looking at these things with the right perspective.
    What do you mean?

    {ShareTopic == 0: //Anxiety
        ** You worry too much about things you can't control. 
            ~reality_awareness += 2
            I just care about the world that live in. I don't see how that is a wrong perspective.
            *** Well if you can't see that, then I can't help you. Have a nice day.
                ~reality_awareness += 2
                Ah, I think I get it now.
                Let me guess, this is your way of feeling superior or something?
                You’re scared to admit I might actually have a point.
                So you just pretend that you’re better than me to make me feel bad about myself. 
                Honestly kinda pathetic.
                ****[*Block Riley*]
                ~ShutUpRiley = true
                ->END
                **** WTF, why are you acting this way? I barely know you.
                    And yet you're the one talk down to me like i'm an idiot.
                    ***** Your right. I'm sorry.
                    ~reality_awareness -= 1
                    ~RileyConnected = true
                    ->stitch1
                
                    ***** Which you are. Its very apparent at this point.
                    ~reality_awareness -= 2
                    ->DONE
                **** The fact that your lashing out like this clearly shows who's got a problem.
                    ~reality_awareness += 1
                    ->DONE
                
            
        ** You easily believe fake sources that do nothing but try and spread fear and anxiety.
            ~reality_awareness += 2
            ->DONE

        
        ** Idk, i guess you're just very opinionated.
            And how is that wrong?
            *** Its not wrong. But its like you're forcing me to agree with you.
                I'm just sharing facts, how can that be forcefull in any way?
                **** But it's not facts. It's fake news created to scare you.
                    Yeah right. You expect me to believe that?
                    *****I would hope that you do.
                        Well thats not happening. 
                        I've followed this news site for a while now.
                        They've never let me down before
                        ->DONE
                        
                        
                    
            *** something
            ->DONE
            
    
        
    }

    {ShareTopic == 1: //Grind Culture
        sdsdsdsd
            ** sdsds
            ->DONE
            ** sdsdsd
            ->DONE
    }

    {ShareTopic == 2: //Body Image
        sdsd
            ** sdsd
            ->DONE
            ** sdsdsd
            ->DONE
    }
}

