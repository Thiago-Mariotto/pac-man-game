var plugin = {
  PlayVideo: function () {
    // Create the event.
    const event = document.createEvent('Event');
  

    // Define that the event name is 'game-finished'.
    event.initEvent('game-finished', true, true);

    window.document.dispatchEvent(event);
  },

}

mergeInto(LibraryManager.library, plugin);