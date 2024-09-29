<template>
  <div
    v-if="isVisible"
    class="modal fade show d-block"
    tabindex="-1"
    role="dialog"
    aria-labelledby="exampleModalComponentsLabel"
    aria-hidden="true"
    style="background: rgba(0, 0, 0, 0);"
  >
    <div class="modal-dialog modal-dialog-centered" role="document">
      <div class="modal-content">
        <!-- Modal Header -->
        <div class="modal-header custom-header">
          <h5 class="modal-title custom-font white-font" id="exampleModalComponentsLabel">
            {{ title }}
          </h5>
        </div>
        <!-- Modal Body -->
        <div class="modal-body custom-font black-font">
          <slot name="body"></slot>
        </div>
        <!-- Modal Footer -->
        <div class="modal-footer">
          <button @click="closeModal" type="button" class="custom-button custom-font white-font">Cerrar</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "ModalComponent",
  props: {
    isVisible: {
      type: Boolean,
      required: true,
    },
    title: {
      type: String,
      default: "Modal title",
    },
  },
  methods: {
    closeModal() {
      this.$emit("close");
    },
  },
};
</script>

<style scoped>
.modal {
  display: block;
}
.custom-font {
  font-size: 20px;
  font-feature-settings: 'liga' off, 'clig' off;
  font-family: Montserrat;
  font-size: 18px;
  font-style: normal;
  font-weight: 500;
}
.black-font {
  color: #000;
}
.white-font {
  color: var(--background, #fbfbfe);
}
.custom-header {
  background: var(--buttons-primary, #8263a8);
  max-width: 100%;
  padding: 10px 20px;
  align-content: center;
  border: none;
}
.custom-button {
  border-radius: 5px;
  background: var(--buttons-primary, #8263a8);
  max-width: 100%;
  padding: 10px 20px;
  align-content: center;
  border: none;
}
</style>