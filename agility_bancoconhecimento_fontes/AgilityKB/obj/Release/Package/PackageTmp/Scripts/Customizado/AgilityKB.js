﻿//Script Exibição Carrossel 
$(document).ready(function () {

    //rotation speed and timer
    var speed = 2000;
    var run = setInterval('rotate()', speed);

    //grab the width and calculate left value
    var item_width = $('#slides li').outerWidth();
    var left_value = item_width * (-1);

    //move the last item before first item, just in case user click prev button
    $('#slides li:last').before($('#slides li:first'));

    //set the default item to the correct position 
    $('#slides ul').css({ 'left': left_value });

    //if user clicked on prev button
    $('#prev').click(function () {

        //get the right position            
        var left_indent = parseInt($('#slides ul').css('left')) + item_width;

        //slide the item            
        $('#slides ul').animate({ 'left': left_indent }, 200, function () {

            //move the last item and put it as first item               
            $('#slides li:first').before($('#slides li:last'));

            //set the default item to correct position
            $('#slides ul').css({ 'left': left_value });

        });

        //cancel the link behavior            
        return false;

    });

    //if user clicked on next button
    $('#next').click(function () {

        //get the right position
        var left_indent = parseInt($('#slides ul').css('left')) - item_width;

        //slide the item
        $('#slides ul').animate({ 'left': left_indent }, 200, function () {

            //move the first item and put it as last item
            $('#slides li:last').after($('#slides li:first'));

            //set the default item to correct position
            $('#slides ul').css({ 'left': left_value });

        });

        //cancel the link behavior
        return false;

    });

    //if mouse hover, pause the auto rotation, otherwise rotate it
    $('#slides').hover(

        function () {
            clearInterval(run);
        },
        function () {
            run = setInterval('rotate()', speed);
        }
    );

});
//Script Exibição Carrossel 

//a simple function to click next link
//a timer will call this function, and the rotation will begin :)  
function rotate() {
    $('#next').click();
}

//Script Para Pop Up Exibição de Perfil
$(function () {
    var moveLeft = -200;
    var moveDown = 10;

    $('a#trigger').hover(function (e) {
        $('div#pop-up').show();
        //.css('top', e.pageY + moveDown)
        //.css('left', e.pageX + moveLeft)
        //.appendTo('body');
    }, function () {
        $('div#pop-up').hide();
    });

    $('a#trigger').mousemove(function (e) {
        $("div#pop-up").css('top', e.pageY + moveDown).css('left', e.pageX + moveLeft);
    });
});
//Script Para Pop Up Exibição de Perfil

