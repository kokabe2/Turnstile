# State Transition Table

## Revision 1

| Current State | Event | Next State | Action |
| ------------- | ----- | ---------- | ------ |
| Locked        | coin  | Unlocked   | unlock |
| Unocked       | pass  | Locked     | lock   |

## Revision 2

| Current State | Event | Next State | Action   |
| ------------- | ----- | ---------- | -------- |
| Locked        | coin  | Unlocked   | unlock   |
| Locked        | pass  | Locked     | alaram   |
| Unocked       | coin  | Unocked    | thankyou |
| Unocked       | pass  | Locked     | lock     |
