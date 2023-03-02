import numpy as np
from matplotlib import pyplot as plt, patches
import mne

from scipy.interpolate import PchipInterpolator,interp1d

import os

from math import cos, pi, sin, radians
from scipy.interpolate import griddata,interp2d

center = (0.5,0.5)
r1 = 0.33
r2 =0.36

ELECTRODES = {
    'FpZ':(0.5+(r1*cos(radians(90))),0.5+(r1*sin(radians(90)))),
    'OZ':(0.5+(r1*cos(radians(270))),0.5+(r1*sin(radians(270)))),
    'PZ':(0.5+(0.16*cos(radians(270))),0.5+(0.16*sin(radians(270)))),
    'FZ':(0.5+(0.16*cos(radians(90))),0.5+(0.16*sin(radians(90)))),
    'CZ':(0.5,0.5),

    'Fp1':(0.5+(r1*cos(radians(115))),0.5+(r1*sin(radians(115)))),
    'Fp2':(0.5+(r1*cos(radians(65))),0.5+(r1*sin(radians(65)))),
    'F7':(0.5+(r1*cos(radians(145))),0.5+(r1*sin(radians(145)))),
    'F8':(0.5+(r1*cos(radians(35))),0.5+(r1*sin(radians(35)))),
    'T7':(0.5+(r1*cos(radians(180))),0.5+(r1*sin(radians(180)))),
    'T8':(0.5+(r1*cos(radians(0))),0.5+(r1*sin(radians(0)))),
    'P7':(0.5+(r1*cos(radians(215))),0.5+(r1*sin(radians(215)))),
    'P8':(0.5+(r1*cos(radians(-35))),0.5+(r1*sin(radians(-35)))),
    'O1':(0.5+(r1*cos(radians(245))),0.5+(r1*sin(radians(245)))),
    'O2':(0.5+(r1*cos(radians(-65))),0.5+(r1*sin(radians(-65)))),

    'F3':(0.5+(0.22*cos(radians(130))),0.5+(0.22*sin(radians(130)))),
    'F4':(0.5+(0.22*cos(radians(50))),0.5+(0.22*sin(radians(50)))),
    'P3':(0.5+(0.22*cos(radians(230))),0.5+(0.22*sin(radians(230)))),
    'P4':(0.5+(0.22*cos(radians(-50))),0.5+(0.22*sin(radians(-50)))),
    'C3':(0.5+(0.16*cos(radians(180))),0.5+(0.16*sin(radians(180)))),
    'C4':(0.5+(0.16*cos(radians(0))),0.5+(0.16*sin(radians(0)))),
}

EDGE_COORDS = [
    (0.5+(r2*cos(radians(90))),0.5+(r2*sin(radians(90)))),
    (0.5+(r2*cos(radians(270))),0.5+(r2*sin(radians(270)))),
    (0.5+(r2*cos(radians(115))),0.5+(r2*sin(radians(115)))),
    (0.5+(r2*cos(radians(65))),0.5+(r2*sin(radians(65)))),
    (0.5+(r2*cos(radians(145))),0.5+(r2*sin(radians(145)))),
    (0.5+(r2*cos(radians(35))),0.5+(r2*sin(radians(35)))),
    (0.5+(r2*cos(radians(180))),0.5+(r2*sin(radians(180)))),
    (0.5+(r2*cos(radians(0))),0.5+(r2*sin(radians(0)))),
    (0.5+(r2*cos(radians(215))),0.5+(r2*sin(radians(215)))),
    (0.5+(r2*cos(radians(-35))),0.5+(r2*sin(radians(-35)))),
    (0.5+(r2*cos(radians(245))),0.5+(r2*sin(radians(245)))),
    (0.5+(r2*cos(radians(-65))),0.5+(r2*sin(radians(-65)))),
]

def draw_electrode(electrodes,ax):
    for electrode in electrodes:
        # circle1 = plt.Circle(ELECTRODES[electrode],
                                # radius=0.04, fill=True,
        #                         facecolor=(0, 0, 0)
        # )
        # circle2 = plt.Circle(ELECTRODES[electrode],
        #                         radius=0.03, fill=True,
        #                         facecolor=(1, 1, 1)
        # )
        # ax.add_artist(circle1)
        # ax.add_artist(circle2)

        position = ELECTRODES[electrode]
        ax.text(position[0], position[1], electrode,
            verticalalignment='center',
            horizontalalignment='center',
            size=6
        )

def draw_nose(ax):
        """Draw nose."""
        nose1 = plt.Line2D([0.45,0.5],
                          [0.9,0.95],
                          linewidth=3,
                          color=(0, 0, 0))
        nose2 = plt.Line2D([0.5,0.55],
                          [0.95,0.9],
                          linewidth=3,
                          color=(0, 0, 0))
        ax.add_line(nose1)
        ax.add_line(nose2)

def montage_plot(eeg_sample,electrodes,ax):
    '''
        
    '''
    # assert eeg_sample.shape[0] == len(electrodes)

    head_outer_circle = patches.Circle(center, radius=0.4, color='black')
    head_inner_circle = patches.Circle(center, radius=0.39, color='white')

    ax.set_aspect(1)
    ax.add_artist(head_outer_circle)
    ax.add_artist(head_inner_circle)

    draw_nose(ax)
    draw_electrode(electrodes,ax)

    points=[]
    # X=list()
    # Y=list()
    for electrode in electrodes:
        # X.append(ELECTRODES[electrode][0])
        # Y.append(ELECTRODES[electrode][1])
        points.append(ELECTRODES[electrode])
    points = points + EDGE_COORDS
    X,Y=np.mgrid[0:1:100j, 0:1:100j]
    Xi,Yi=np.meshgrid(X,Y)
    points = np.array(points)

    mu = np.mean(eeg_sample,0)
    mu_add = np.ones((len(EDGE_COORDS)))*mu

    data_sample = np.hstack((eeg_sample,mu_add))

    
    Z=griddata(points,data_sample,(Xi,Yi),'cubic')

    # im = ax.imshow(Z, interpolation='bilinear', origin='lower', cmap=cm.gray, extent=(0,1,0,1))

    ax.set_ylim(0,1)
    ax.set_xlim(0,1)

    # levels = np.arange(-1.2,1.6,0.2)
    color_s=['lightblue','powderblue','cyan','aqua','palegreen','lightgreen','springgreen']
    color_s = color_s + ['darkslategray','darksalmon','lightcoral','indianred','orangered','red','crimson']
    CS = ax.contour(Xi,Yi,Z,25,cmap='RdBu',extend='both',linewidths=20,extent=(0,1,0,1))
    CS.collections[6].set_linewidth(30)

    ax.get_xaxis().set_ticks([])
    ax.get_yaxis().set_ticks([])
    # plt.show()

def stft_plot(ax,data,title,fs=9,sfreq=200):
    f=mne.time_frequency.stftfreq((fs-1)*2,sfreq)
    ax.pcolormesh(
        list(range(data.shape[-1])),
        f,
        np.abs(data),
        shading='gouraud'
    )
    ax.set_xlabel('Time(ms)')
    ax.set_ylabel('Frequency(Hz)')
    ax.set_title(title)

def time_series_plot(ax,data,color,stim,xi,x,c):
    ax.plot(
        data,
        color,
        label=stim,
        linestyle='-',
    )
    ax.set_xticks(xi,x)
    # ax.set_xlabel('Time(s)')
    ax.set_title(c)

def mmn_plot(ax,data,ch,points=15):
    xi=list(range(0,data['1000Hz'].shape[1],points))
    x=(np.array(xi)/200).tolist()
    for r in range(data['1000Hz'].shape[0]):
        for st,stim in enumerate(data):
            if stim == '1000Hz':
                color='#d7d0cf'
                time_series_plot(ax[r],data[stim][r,:],color,stim,xi,x,ch[r])
            elif stim == ' ':
                color='#868483'
            else:
                color='#3b3a3a'
                time_series_plot(ax[r],data[stim][r,:],color,stim,xi,x,ch[r])
        if r==0:
            # ax[r].legend(loc='upper left',fontsize=6)
            ax[r].set_ylabel('Amplitude(uV)')
        if r!=0:
            ax[r].set_ylabel(' ')

def electrodes_mmn_plot(ax,data,c0,c1,electrodes,points):
    mmn_data={
        ' ':data[' '][c0:c1,:],
        '1000Hz':data['1000Hz'][c0:c1,:],
        '3000Hz':data['3000Hz'][c0:c1,:],
    }
    mmn_plot(ax,mmn_data,electrodes[c0:c1],points)

def entropy_plot(ax,data,pos):
    if len(data) > 2:
        data=np.array(data).mean()
    ax.bar(pos,data,1)
    ax.set_xticks([1,2,3,4],['F','P/C','P/O','T/O'])
    ax.set_ylabel('FuzzEnt')