# Interacting with PC using Facial Gesture Recognition
--------------
This is a Pattern Recognition subject project at my BSc Study.

Introduction
-------
Gesture recognition pertains to recognizing meaningful expressions of motion by a human, involving
the hands, arms, face, and/or body. It is of utmost importance in designing an intelligent and efficient
human–computer interface. Gestures are expressive, meaningful body motions involving physical
movements of the fingers, hands, arms, face, or body with the intent of: 1) conveying non-verbal
meaningful information; or 2) interacting with the environment. Gesture recognition has wide-ranging
applications, one of them is enabling human to interact with computers using face gestures.
Facial gesture expressions involve extracting sensitive features from facial landmarks such as regions
surrounding the mouth, nose, and eyes of a normalized image.The features under consideration here
are the eyebrows, eyes, nostrils, mouth, cheeks, and chin.

Objective
-------
The goal of this project is to classify the gestures of a centered image of a head to four classes, as
either the person is looking down, left, front, or closing his\her eyes, as shown in fig.1. There are
different predefined actions related to each class for computer control. As shown in fig.1, the four
actions are minimize, restore, open, and close a dialog of windows media player.

Dataset
-------
The dataset is real-world data, gathered from BioID Face Database[1]. The dataset consists of 80
gray level images (patterns) (20 images/class) with a resolution of 384x286 pixel. Each one
shows the frontal view of a face of one out of 23 different test persons. The images are labeled
"BioID_xxxx.pgm", where the characters xxxx are replaced by the index of the current image
(with leading zeros), for more information about image file format, see [1]. Similar to this, the
files "BioID_xxxx.pts" contain the positions of 20 facial landmarks for the corresponding images,
as shown in fig.3. The data in a pts file is stored as follows:
- 0 = right eye pupil
- 1 = left eye pupil
- 2 = right mouth corner
- 3 = left mouth corner
- 4 = outer end of right eye brow
- 5 = inner end of right eye brow
- 6 = inner end of left eye brow
- 7 = outer end of left eye brow
- 8 = right temple
- 9 = outer corner of right eye
- 10 = inner corner of right eye
- 11 = inner corner of left eye
- 12 = outer corner of left eye
- 13 = left temple
- 14 = tip of nose
- 15 = right nostril
- 16 = left nsostril
- 17 = center point on outer edge of upper lip
- 18 = center point on outer edge of lower lip
- 19 = tip of chin

Classification Algorithms
---------------
We had implemented the following classifiers for recognizing facial gestures:
1. Bayesian Classifier.
2. K-Nearest Neighbor Classifier
3. Probabilistic Neural Networks
