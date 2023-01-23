import numpy as np
import mne

def trial_baseline_correction(subject_trial):
    if subject_trial[1].all()!=None:
        mean = np.mean(subject_trial[1][:,0:100],1)
        for phase in subject_trial.keys():
            for c in range(subject_trial[phase].shape[1]):
                subject_trial[phase][:,c]=subject_trial[phase][:,c]-mean

def all_subjects_baseline_correction(all_subjects_data):
    for subject in all_subjects_data:
        for trial in subject:
            trial_baseline_correction(trial)

def filter_epoch(epoch,lfreq=1,hfreq=30,sfreq=100):
    filter=mne.decoding.TemporalFilter(lfreq,hfreq,sfreq)
    return filter.transform(epoch)

def filter_epochs(epochs,lfreq=1,hfreq=30,sfreq=100):
    assert isinstance(epochs,dict)
    filtered_epochs=dict()
    for k in epochs.keys():
        filtered_epochs[k]=filter_epoch(epochs[k],lfreq,hfreq,sfreq)
    
    return filtered_epochs
