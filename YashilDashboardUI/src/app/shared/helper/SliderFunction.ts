export function SliderFunction(sliderContent, value, currentSliderId) {
  let id = currentSliderId;
  if (value === 'next') {
    if (id === sliderContent.length - 1) {
      id = 0;
    } else {
      id++;
    }
  }
  if (value === 'prev') {
    if (id === 0) {
      id = sliderContent.length - 1;
    } else {
      id--;
    }
  }

  return id;
}
