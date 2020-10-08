<template>
  <div>
    <div class="content">
      <i class="fas fa-circle bullet-point"></i>

      <textarea v-if="entry.focused" v-model="this.currentEntry.content" ref="ta"
                @keyup="autoheight($event)"></textarea>

      <div v-if="!entry.focused" v-html="renderedContent" @click="focusEntry()"></div>
    </div>

    <div class="children">
      <entry-display v-for="child in entry.children" v-bind:key="child.id" :entry="child"
                     @entry-focused="$emit('entry-focused', $event)"></entry-display>
    </div>
  </div>
</template>

<script>
import * as marked from 'marked';

export default {
  name: 'EntryDisplay',
  props: {
    entry: Object
  },
  data() {
    return {
      currentEntry: this.entry
    }
  },
  computed: {
    renderedContent() {
      return marked(this.currentEntry.content);
    }
  },
  methods: {
    focusEntry() {
      this.$emit('entry-focused', this.currentEntry.id);
    },
    autoheight(x) {
      this.$refs.ta.style.height = "5px";
      this.$refs.ta.style.height = (15 + x.scrollHeight) + "px";
    }
  },
  updated() {
    if (this.$refs.ta) {
      this.$refs.ta.focus();
    }
  }
}
</script>

<style scoped>
textarea {
  border: none;
  outline: none;
  box-shadow: none;
  padding: 0;
}

.content {
  display: flex;
}

.children {
  padding-left: 15px;
  border-left: 1px solid lightgray;
}

.bullet-point {
  margin-left: -2px;
  margin-right: 5px;
  padding-top: 1.5em;
  font-size: 0.4em;
}

</style>
