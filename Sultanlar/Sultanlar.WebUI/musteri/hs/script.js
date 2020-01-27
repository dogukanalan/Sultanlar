$(document).ready(function () {
    /* ---------------------------------------------------------------------- */
    /*	Portfolio Page
    /* ---------------------------------------------------------------------- */
    var $portfoliocontainer = $('#portfolio-container');
    var $portfoliofilter = $('#portfolio-menu');

    $portfoliocontainer.isotope({
        filter: '*',
        layoutMode: 'masonry',
        animationOptions: {
            duration: 600,
            easing: 'linear'
        }
    });

    $portfoliofilter.find('a').click(function () {
        var selector = $(this).attr('data-filter');
        $portfoliocontainer.isotope({
            filter: selector,
            animationOptions: {
                duration: 600,
                easing: 'linear',
                queue: false
            }
        });
        return false;
    });

    $portfoliocontainer.find('img').adipoli({
        'startEffect': 'transparent',
        'hoverEffect': 'boxRandom',
        'imageOpacity': 0.5,
        'animSpeed': 100
    });

    $portfoliofilter.find('a').click(function () {
        var currentOption = $(this).attr('data-filter');
        $portfoliofilter.find('a').removeClass('current');
        $(this).addClass('current');
    });

    $(".popup").fancybox({
        openEffect: 'fade',
        closeEffect: 'fade',
        scrolling: 'no',
        keys: {
            next: {
                13: 'left', // enter
                34: 'up',   // page down
                39: 'left', // right arrow
                40: 'up'    // down arrow
            },
            prev: {
                8: 'right',  // backspace
                33: 'down',   // page up
                37: 'right',  // left arrow
                38: 'down'    // up arrow
            },
            close: [27], // escape key
            play: [32], // space - start/stop slideshow
            toggle: [70]  // letter "f" - toggle fullscreen
        }
    });

    $('#portfolio-container a.group').lightbox();

    // Portfolio Page - Choose Categories
    $('#portfolio .groups').unbind("click").click(function () {
        var idButton = $(this).attr('id');
        $('#portfolio .groups').removeClass('active');
        $(this).addClass('active');
        $('#portfolio-container li').fadeOut(timeFade / 4);
        setTimeout(function () {
            $('#portfolio-container li a').each(function () {
                var elemGroup = $(this).attr('data-group');
                var buttonGroup = idButton;
                if (idButton != 'allgroups') {
                    if (buttonGroup == elemGroup) {
                        $(this).parent().fadeIn(timeFade);
                    }
                } else {
                    $(this).parent().fadeIn(timeFade);
                }
            });
        }, timeFade);
        // Close lightbox to open again (with the category selected or all)
        $('#lightbox').remove();
        // Dinamic Group
        if (idButton == 'allgroups') {
            // Create lightbox for "All Groups"
            $('#portfolio-container a.group').lightbox();
        } else {
            // Create lightbox for "Selected Group"
            $('#portfolio-container a[data-group="' + idButton + '"').lightbox();
        }
    });
});