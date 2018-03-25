const Discord = require('discord.js');
const bot = new Discord.Client();

bot.on('message', (message) => {

    var msg = message.content;
    var msgL = msg.toLowerCase();
    var dadName = "";
    var legFacts = [
        "Svetlana Pankratova from Russia, was the woman with the longest legs in the world, at 132cm. Impressive feat!",
        "Michael Flatley, star of Riverdance, had his legs insured in 1999 for $40 million! Don't tell him to 'break a leg'!",
        "A robot in Undertale have very flamboint legs!",
        "The body's longest muscle is the sartorius! It runs from the hip to the knee! We knee'd it badly.",
        "The term 'break a leg' is refering to an old superstition in which wishing someone good luck is bad luck. Vice versa.",
        "In 1836, Mexican General Santa Anna held a state funeral for his amputated leg. It was probably dead weight anyways.",
        "The elephant is the only land mammal that cannot jump! It's bodyweight is simply too much for any joint to survive. Kinda like me...",
        "Centipedes do not have 100 legs and millipedes do not have 1000 legs. These namers have to quit pulling our legs.",
        "Standing is more tiring than walking!",
        "The volume of a human's foot increases during the evening. There can be up to an 8% difference in foot size during the morning and evening! Something strange is afoot!",
        "Beethoven used to take hay baths to counter the swelling he used to get in his legs! I mean, hay, if it works.",
        "The normal person walks about 43.5 miles in a life span.",
        "When a horse fracture their legs, they are typically euthanized. Horses tend to put strain on the broken leg. It can't heel.",
        "Our feet and ankles have a total of 52 bones!",
        "The Daddy Longlegs spider is not actually a spider! They only have one pair of eyes and a singular, fused body. Search up the web!",
        "The human legs are unique because they are powerful and long enough for locomotion and support the body!"
    ];

    if(msgL == 'leg')
    {

        message.channel.sendMessage('DAY!');
    }

    if(msg == "Hey, Carlos! How are you?" || msg == "I'm doing well! How about you, Carlos?")
    {
        message.channel.sendMessage("~I'm fine! How about you, Bread-chan?");
    }

    if(msgL == '~leg fact')
    {
        rnd = Math.floor(Math.random()*(legFacts.length+1))
        message.channel.sendMessage(legFacts[rnd]);
    }

    if(msgL == "i'm carlos" || msgL == "im carlos")
    {
        dadName = msg.substring(4, msg.length);
        message.channel.sendMessage("NO! I'm Carlos!");
    } else if(msgL == "thanks carlos" || msgL == "thanks, carlos")
    {
        message.channel.sendMessage("No problem, my friend!");
    } else{
        if(msgL.startsWith("i'm ") || msgL.startsWith("im "))
        {
        dadName = msg.substring(4, msg.length);
        message.channel.sendMessage("Hi, " + dadName + ". I'm Carlos!");
        }

        if (msgL.startsWith("im "))
        {
            dadName = msg.substring(3, msg.length);
            message.channel.sendMessage("Hi, " + dadName + ". I'm Carlos!");
        }
    }

})

bot.login('the token goes here. i keep the token secret');
