-> ACT1

=== ACT1 ===
/* 
1. Setting Up the Profile
(The player enters a username and selects an avatar image)

System Message:
Welcome to YapChat! Let’s start by setting up your profile. Choose your avatar and add a
username to start connecting with friends.

(Player completes profile setup)

2. Friend Request from Sam
(Player enters main feed and sees a notification)

System Message:
You have a new friend request from Sam.

(Player accepts the friend request and goes to the chat section of YapChat!)
*/

// First interaction - welcome to YapChat
= stitch1
About time you got your account set up. What took you so long? #speaker:Sam #portrait:sam #layout:right
    * Sorry about that. Had to help my mom with something before I could get to my computer. #speaker:Player #portrait:player #layout:left
    * I’ve almost just started my computer. I literally couldn’t be here any quicker #speaker:Player #portrait:player #layout:left

- It’s fine, no worries. #speaker:Sam #portrait:sam #layout:right
-> stitch2

// Second interaction - Tutorial - basics of system
= stitch2
Anyway, welcome to YapChat!. #speaker:Sam #portrait:sam #layout:right
    * Thank you. Feels a lot like a mixture between Facebonk and Instablam. #speaker:Player #portrait:player #layout:left
        Yeah, that’s what gives it its charm. #speaker:Sam #portrait:sam #layout:right
        It is condensed to basically two aspects. #speaker:Sam #portrait:sam #layout:right
        Liking and sharing content from the feed, and then chatting about the content with your friends. #speaker:Sam #portrait:sam #layout:right
        You can try sharing something on the feed with me, just to get a hang of things. #speaker:Sam #portrait:sam #layout:right
            ** Will do. #speaker:Player #portrait:player #layout:left
            -> DONE
            ** I'll go browse the feed then. #speaker:Player #portrait:player #layout:left
            -> DONE

    * Thanks. Think i’ll have a look around YapChat! and explore it a bit.  #speaker:Player #portrait:player #layout:left
        Sure.  #speaker:Sam #portrait:sam #layout:right
        Np. #speaker:Sam #portrait:sam #layout:right
            ** Feels a lot like a mixture between Facebonk and Instablam. #speaker:Player #portrait:player #layout:left
            Yeah, that’s what gives it its charm. #speaker:Sam #portrait:sam #layout:right
            It is condensed to basically two aspects. #speaker:Sam #portrait:sam #layout:right 
            Liking and sharing content from the feed, and then chatting about the content with your friends. #speaker:Sam #portrait:sam #layout:right
            You can try sharing something on the feed with me, just to get a hang of things. #speaker:Sam #portrait:sam #layout:right
                *** Will do. #speaker:Player #portrait:player #layout:left
                -> DONE
                *** I'll go browse the feed then. #speaker:Player #portrait:player #layout:left
                -> DONE
            ** I don't think i understand how this works, could you explain it to me? #speaker:Player #portrait:player #layout:left
                Well it is rather simple actually. There are basically only two aspects to YapChat!. #speaker:Sam #portrait:sam #layout:right
                Liking and sharing content from the feed, and then chatting about the content with your friends. #speaker:Sam #portrait:sam #layout:right
                That is why there are only two tabs you will see on the home page. #speaker:Sam #portrait:sam #layout:right
                You can try sharing something on the feed with me, just to get a hang of things. #speaker:Sam #portrait:sam #layout:right
                *** Will do. #speaker:Player #portrait:player #layout:left
                -> DONE
                *** I'll go browse the feed then. #speaker:Player #portrait:player #layout:left
                -> DONE
            -> DONE
                
    * I’ve never had a social media account before so would you mind helping me understand how i navigate? #speaker:Player #portrait:player #layout:left
        Really? #speaker:Sam #portrait:sam #layout:right
        Well it is rather simple actually. #speaker:Sam #portrait:sam #layout:right
        There are basically only two aspects to YapChat!. #speaker:Sam #portrait:sam #layout:right
        Liking and sharing content from the feed, and then chatting about the content with your friends. #speaker:Sam #portrait:sam #layout:right
        That is why there are only two tabs you will see on the home page. #speaker:Sam #portrait:sam #layout:right
        You can try sharing something on the feed with me, just to get a hang of things. #speaker:Sam #portrait:sam #layout:right
            ** Will do. #speaker:Player #portrait:player #layout:left
            -> DONE
            ** I'll go browse the feed then. #speaker:Player #portrait:player #layout:left
            -> DONE

// Third interaction - Discussing shared post
=stitch3
VAR sharedPost = 0

{sharedPost:
- 0: Nice! It seems like you’ve got the hang of things. Unfortunately I have to go now, but I'll see you at school tomorrow. #speaker:Sam #portrait:sam #layout:right
- 1: HAHA! good one. It seems like you’ve got the hang of things. Unfortunately I have to go now, but I'll see you at school tomorrow. #speaker:Sam #portrait:sam #layout:right
-2: Hmmm. Not really something i agree with, but it seems like you’ve got the hang of things. Unfortunately I have to go now, but I'll see you at school tomorrow. #speaker:Sam #portrait:sam #layout:right
}

    * Oh. Ok. Yeah, see ya tomorrow #speaker:Player #portrait:player #layout:left
    -> DONE
    * See ya #speaker:Player #portrait:player #layout:left
    -> DONE
    
/*
5. Friend Request from Riley
(After a few seconds, the player gets a notification)

System Message:
You have a new friend request from Riley.

(Act 1 ends) (fade to black)
*/

-> END