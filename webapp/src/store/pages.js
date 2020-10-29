import { createStore } from 'vuex';

export default createStore({
  state() {
    return {
      page: {
        id: 1,
        title: 'Page Header from store',
        children: [
          {
            id: 1,
            content: 'Hello World',
            children: [{
              id: 2,
              content: 'Child of 1 **strong**',
              children: [{
                id: 3,
                content: 'Sub-Child of 2 **strong too**',
                children: []
              }, {
                id: 4,
                content: 'Another sub-Child of 2 _italic_\n\nnewline',
                children: []
              }]
            }]
          },
          {
            id: 5,
            content: 'Second Entry',
            children: []
          }
        ]
      }
    }
  },
  getters: {
    numOfChildren(state) {
      return state.page.children.length;
    }
  }
});

