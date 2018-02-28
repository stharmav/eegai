# eegai
Intrusive Thoughts Simulator

To run:
1) Make sure your muse is connected to your computer.
2) Run Muse-IO to stream EEG data. Recommended streaming to localhost, port 5000:
```muse-io --osc osc.udp://localhost:15000```
When successful, it'll show a status message and have live counts along the lines of:
```bits/second: 7090       receiving at: 220.00Hz          dropped samples: 0```
3) Run the VR app in Unity. Three log messages should show up:
```
Opening OSC listener on port 15000
Started
Listening at /muse/elements/alpha_absolute
```

Once everything is working, some text should be showing in realtime updating you on your alpha level.
