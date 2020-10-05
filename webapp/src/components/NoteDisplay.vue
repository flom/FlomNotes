<template>
  <div>
    <h1>{{ note.title }}</h1>
    <button class="button" @click="printOut()">debug</button>
    <div v-for="child in note.children" v-bind:key="child.id">
      <entry-display :entry="child" @unfocus="unfocus($event)"></entry-display>
    </div>
  </div>
</template>

<script>
  import EntryDisplay from './EntryDisplay';

  export default {
    name: 'NoteDisplay',
    components: {
      EntryDisplay
    },
    data() {
      return {
        note: {
          id: 1,
          title: 'Note Header',
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
                }]
              }]
            },
            {
              id: 4,
              content: 'Second Entry',
              children: []
            }
          ]
        }
      }
    },
    methods: {
      unfocus(sourceEntryId) {
        console.log('unfocus', sourceEntryId);
        /*
        let queue = this.note.children;
        while (queue.length > 0) {
          const entry = queue.splice(0, 1);
          if (entry.id !== sourceEntryId) {
            entry.focused = false;
          }
          queue = queue.concat(entry.children);
        }
         */
      },
      printOut() {
        console.log(this.note);
      }
    }
  }
</script>

<style scoped>

</style>
