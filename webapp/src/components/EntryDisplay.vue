<template>
  <div>
    <div class="content">
      <i class="fas fa-circle bullet-point"></i>

      <textarea v-if="entry.focused" v-model="this.currentEntry.content" ref="ta"
                @focusout="unfocusEntry()" @keyup="onKeyUp()"
                style="overflow: hidden; height: 30px"></textarea>

      <div v-if="!entry.focused" v-html="renderedContent" @click="focusEntry()"
           class="rendered-content"></div>
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
    unfocusEntry() {
      this.$emit('entry-focused', null);
    },
    onKeyUp() {
      this.updateTextAreaHeight();
    },
    updateTextAreaHeight() {
      this.$refs.ta.style.height = this.$refs.ta.scrollHeight + 'px';
    }
  },
  updated() {
    if (this.$refs.ta) {
      this.$refs.ta.focus();
      this.updateTextAreaHeight();
    }
  }
}
</script>

<style scoped>
textarea {
  border: none;
  /*border: 1px solid black;*/
  outline: none;
  box-shadow: none;
  padding: 0;
  resize: none;
  min-height: 24px;
  margin-bottom: 0;
}

textarea:focus {
  outline: none;
  border: none;
  /*border: 1px solid black;*/
  box-shadow: none;
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

.rendered-content {
  margin-bottom: 5px;
}

.rendered-content >>> p {
  margin-bottom: 0;
}

</style>
