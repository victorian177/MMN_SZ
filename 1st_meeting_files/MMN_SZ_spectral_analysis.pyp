<?xml version='1.0' encoding='utf-8'?>
<scheme description="" title="MMN_SZ_spectral_analysis" version="2.0">
	<nodes>
		<node id="0" name="Power Spectrum (Welch)" position="(529.0, 256.0)" project_name="NeuroPype" qualified_name="widgets.spectral.owwelchspectrum.OWWelchSpectrum" title="Power Spectrum (Welch)" uuid="6c6df3ef-888f-4ce8-8e54-d4a77100096e" version="1.0.0" />
		<node id="1" name="Record to XDF" position="(360.0, 434.0)" project_name="NeuroPype" qualified_name="widgets.file_system.owrecordtoxdf.OWRecordToXDF" title="Record to XDF (externals)" uuid="9a1b2ddb-7164-4e23-aa56-0808ff2ee136" version="1.0.0" />
		<node id="2" name="Stream Data" position="(173.0, 256.0)" project_name="NeuroPype" qualified_name="widgets.formatting.owstreamdata.OWStreamData" title="Stream Data" uuid="f04c7d6f-e827-4a1c-85fe-697fff6fe1a8" version="1.1.0" />
		<node id="3" name="Spectrum Plot" position="(650.0, 257.0)" project_name="NeuroPype" qualified_name="widgets.visualization.owspectrumplot.OWSpectrumPlot" title="Spectrum Plot" uuid="c3bf8d79-0b4a-4074-9343-efde6ec6f38e" version="1.0.0" />
		<node id="4" name="Import XDF" position="(69.0, 257.0)" project_name="NeuroPype" qualified_name="widgets.file_system.owimportxdf.OWImportXDF" title="Import XDF" uuid="fafcc49b-8462-43c4-bc9b-d1ea76d526d0" version="1.0.0" />
		<node id="5" name="Segmentation" position="(407.0, 249.0)" project_name="NeuroPype" qualified_name="widgets.formatting.owsegmentation.OWSegmentation" title="Segmentation" uuid="850c360a-4f40-47c0-9c10-77acb7b8e0fb" version="1.0.1" />
		<node id="6" name="Time Series Plot" position="(526.0, 140.0)" project_name="NeuroPype" qualified_name="widgets.visualization.owtimeseriesplot.OWTimeSeriesPlot" title="Time Series Plot (1)" uuid="3e245a16-09da-4817-94df-03f1966a4163" version="1.0.1" />
		<node id="7" name="FIR Filter" position="(292.0, 256.0)" project_name="NeuroPype" qualified_name="widgets.signal_processing.owfirfilter.OWFIRFilter" title="FIR Filter" uuid="f2860839-b8ca-4402-a2b6-4c599cb4153f" version="1.0.0" />
		<node id="8" name="Continuous Wavelet Transform" position="(524.0, 379.0)" project_name="NeuroPype" qualified_name="widgets.spectral.owcontinuouswavelettransform.OWContinuousWaveletTransform" title="Continuous Wavelet Transform" uuid="8203bf5c-d33a-466c-986e-93e46074f4eb" version="1.0.0" />
		<node id="9" name="Time Series Plot" position="(639.0, 380.0)" project_name="NeuroPype" qualified_name="widgets.visualization.owtimeseriesplot.OWTimeSeriesPlot" title="ctft" uuid="05058dd1-ad89-425e-a333-bc4fbd6f8110" version="1.0.1" />
		<node id="10" name="Record to XDF" position="(360.0, 434.0)" project_name="NeuroPype" qualified_name="widgets.file_system.owrecordtoxdf.OWRecordToXDF" title="Record to XDF (externals)" uuid="da02cc0a-6859-45a7-a661-b390f1221482" version="1.0.0" />
		<node id="11" name="Record to CSV" position="(612.0, 467.0)" project_name="NeuroPype" qualified_name="widgets.file_system.owrecordtocsv.OWRecordToCSV" title="Record to CSV" uuid="81c8d872-d0c9-4503-96eb-918cfa59e3a3" version="1.0.0" />
	</nodes>
	<links>
		<link enabled="true" id="0" sink_channel="Data" sink_node_id="3" source_channel="Data" source_node_id="0" />
		<link enabled="true" id="1" sink_channel="Data" sink_node_id="2" source_channel="Data" source_node_id="4" />
		<link enabled="true" id="2" sink_channel="Data" sink_node_id="7" source_channel="Data" source_node_id="2" />
		<link enabled="true" id="3" sink_channel="Data" sink_node_id="5" source_channel="Data" source_node_id="7" />
		<link enabled="true" id="4" sink_channel="Data" sink_node_id="1" source_channel="Data" source_node_id="7" />
		<link enabled="true" id="5" sink_channel="Data" sink_node_id="6" source_channel="Data" source_node_id="5" />
		<link enabled="true" id="6" sink_channel="Data" sink_node_id="0" source_channel="Data" source_node_id="5" />
		<link enabled="true" id="7" sink_channel="Data" sink_node_id="8" source_channel="Data" source_node_id="5" />
		<link enabled="true" id="8" sink_channel="Data" sink_node_id="9" source_channel="Data" source_node_id="8" />
		<link enabled="true" id="9" sink_channel="Data" sink_node_id="11" source_channel="Data" source_node_id="8" />
	</links>
	<annotations />
	<thumbnail />
	<node_properties>
		<properties format="pickle" node_id="0">gAN9cQAoWBgAAABhdmVyYWdlX292ZXJfdGltZV93aW5kb3dxAYlYBAAAAGF4aXNxAlgEAAAAdGlt
ZXEDWAcAAABkZXRyZW5kcQRYCAAAAGNvbnN0YW50cQVYCAAAAGZmdF9zaXplcQZYDQAAACh1c2Ug
ZGVmYXVsdClxB1gIAAAAb25lc2lkZWRxCIhYDwAAAG92ZXJsYXBfc2FtcGxlc3EJWA0AAAAodXNl
IGRlZmF1bHQpcQpYEwAAAHNhdmVkV2lkZ2V0R2VvbWV0cnlxC2NzaXAKX3VucGlja2xlX3R5cGUK
cQxYDAAAAFB5UXQ0LlF0Q29yZXENWAoAAABRQnl0ZUFycmF5cQ5DLgHZ0MsAAQAAAAADAwAAAagA
AAR8AAACcgAAAwwAAAHOAAAEcwAAAmkAAAAAAABxD4VxEIdxEVJxElgHAAAAc2NhbGluZ3ETWAcA
AABkZW5zaXR5cRRYDwAAAHNlZ21lbnRfc2FtcGxlc3EVWA0AAAAodXNlIGRlZmF1bHQpcRZYDgAA
AHNldF9icmVha3BvaW50cReJWAQAAAB1bml0cRhYBwAAAHNhbXBsZXNxGVgGAAAAd2luZG93cRpY
BAAAAGhhbm5xG3Uu
</properties>
		<properties format="pickle" node_id="1">gAN9cQAoWAwAAABhbGxvd19kb3VibGVxAYlYDwAAAGNsb3NlX29uX21hcmtlcnECWA8AAABjbG9z
ZS1yZWNvcmRpbmdxA1gNAAAAY2xvdWRfYWNjb3VudHEEWAAAAABxBVgMAAAAY2xvdWRfYnVja2V0
cQZoBVgRAAAAY2xvdWRfY3JlZGVudGlhbHNxB2gFWAoAAABjbG91ZF9ob3N0cQhYBwAAAERlZmF1
bHRxCVgOAAAAY2xvdWRfcGFydHNpemVxCkseWAwAAABkZWxldGVfcGFydHNxC4hYCAAAAGZpbGVu
YW1lcQxYLwAAAEQ6L0VtbWFudWVsX3BldHJvbl9PbGF0ZWp1L01NTl9TWi9leHRlcm5hbHMueGRm
cQ1YCwAAAG91dHB1dF9yb290cQ5oBVgLAAAAcmV0cmlldmFibGVxD4lYEwAAAHNhdmVkV2lkZ2V0
R2VvbWV0cnlxEGNzaXAKX3VucGlja2xlX3R5cGUKcRFYDAAAAFB5UXQ0LlF0Q29yZXESWAoAAABR
Qnl0ZUFycmF5cRNDLgHZ0MsAAQAAAAADAwAAAUEAAAR8AAAC2QAAAwwAAAFnAAAEcwAAAtAAAAAA
AABxFIVxFYdxFlJxF1gNAAAAc2Vzc2lvbl9ub3Rlc3EYaAVYDgAAAHNldF9icmVha3BvaW50cRmJ
WAcAAAB2ZXJib3NlcRqJdS4=
</properties>
		<properties format="literal" node_id="2">{'hitch_probability': 0.0, 'jitter_percent': 5, 'looping': True, 'randseed': 34535, 'savedWidgetGeometry': None, 'set_breakpoint': False, 'speedup': 1.0, 'start_pos': 0.0, 'timestamp_jitter': 0.0, 'timing': 'wallclock', 'update_interval': 0.04}</properties>
		<properties format="pickle" node_id="3">gAN9cQAoWA0AAABhbHdheXNfb25fdG9wcQGJWAsAAABhbnRpYWxpYXNlZHECiFgJAAAAYXV0b3Nj
YWxlcQOIWBAAAABiYWNrZ3JvdW5kX2NvbG9ycQRYBwAAACNGRkZGRkZxBVgQAAAAZGVjb3JhdGlv
bl9jb2xvcnEGWAcAAAAjMDAwMDAwcQdYCwAAAGRvd25zYW1wbGVkcQiJWAwAAABpbml0aWFsX2Rp
bXNxCV1xCihLMksyTbwCTfQBZVgKAAAAbGluZV9jb2xvcnELWAcAAAAjMDAwMDAwcQxYCgAAAGxp
bmVfd2lkdGhxDUc/6AAAAAAAAFgVAAAAb25lX292ZXJfZl9jb3JyZWN0aW9ucQ6JWBMAAABzYXZl
ZFdpZGdldEdlb21ldHJ5cQ9jc2lwCl91bnBpY2tsZV90eXBlCnEQWAwAAABQeVF0NC5RdENvcmVx
EVgKAAAAUUJ5dGVBcnJheXESQy4B2dDLAAEAAAAAAwMAAAF3AAAEfAAAAqMAAAMMAAABnQAABHMA
AAKaAAAAAAAAcROFcRSHcRVScRZYBQAAAHNjYWxlcRdHP/AAAAAAAABYDgAAAHNldF9icmVha3Bv
aW50cRiJWAcAAABzdGFja2VkcRmIWAsAAABzdHJlYW1fbmFtZXEaWA0AAAAodXNlIGRlZmF1bHQp
cRtYBQAAAHRpdGxlcRxYDQAAAFNwZWN0cnVtIHZpZXdxHVgKAAAAemVyb19jb2xvcnEeWAkAAAAj
N0Y3RjdGN0ZxH3Uu
</properties>
		<properties format="pickle" node_id="4">gAN9cQAoWA0AAABjbG91ZF9hY2NvdW50cQFYAAAAAHECWAwAAABjbG91ZF9idWNrZXRxA2gCWBEA
AABjbG91ZF9jcmVkZW50aWFsc3EEaAJYCgAAAGNsb3VkX2hvc3RxBVgHAAAARGVmYXVsdHEGWAgA
AABmaWxlbmFtZXEHWCgAAABEOi9FbW1hbnVlbF9wZXRyb25fT2xhdGVqdS9NTU5fU1ovMTIueGRm
cQhYEwAAAGhhbmRsZV9jbG9ja19yZXNldHNxCYhYEQAAAGhhbmRsZV9jbG9ja19zeW5jcQqIWBUA
AABoYW5kbGVfaml0dGVyX3JlbW92YWxxC4hYDgAAAG1heF9tYXJrZXJfbGVucQxYDQAAACh1c2Ug
ZGVmYXVsdClxDVgSAAAAcmVvcmRlcl90aW1lc3RhbXBzcQ6JWA4AAAByZXRhaW5fc3RyZWFtc3EP
aA1YEwAAAHNhdmVkV2lkZ2V0R2VvbWV0cnlxEGNzaXAKX3VucGlja2xlX3R5cGUKcRFYDAAAAFB5
UXQ0LlF0Q29yZXESWAoAAABRQnl0ZUFycmF5cRNDLgHZ0MsAAQAAAAADAwAAAYAAAAR8AAACmgAA
AwwAAAGmAAAEcwAAApEAAAAAAABxFIVxFYdxFlJxF1gOAAAAc2V0X2JyZWFrcG9pbnRxGIlYDwAA
AHVzZV9zdHJlYW1uYW1lc3EZiVgHAAAAdmVyYm9zZXEaiXUu
</properties>
		<properties format="pickle" node_id="5">gAN9cQAoWBEAAABrZWVwX21hcmtlcl9jaHVua3EBiVgOAAAAbWF4X2dhcF9sZW5ndGhxAkc/yZmZ
mZmZmlgPAAAAb25saW5lX2Vwb2NoaW5ncQNYDQAAAG1hcmtlci1sb2NrZWRxBFgNAAAAc2FtcGxl
X29mZnNldHEFSwBYEwAAAHNhdmVkV2lkZ2V0R2VvbWV0cnlxBmNzaXAKX3VucGlja2xlX3R5cGUK
cQdYDAAAAFB5UXQ0LlF0Q29yZXEIWAoAAABRQnl0ZUFycmF5cQlDLgHZ0MsAAQAAAAADAwAAAYIA
AAR8AAACmAAAAwwAAAGoAAAEcwAAAo8AAAAAAABxCoVxC4dxDFJxDVgOAAAAc2VsZWN0X21hcmtl
cnNxDl1xDyhYCwAAAGNhbGliLWJlZ2lucRBYBAAAAHJlc3RxEVgPAAAAYWN0aXZlX21vdmVtZW50
cRJlWA4AAABzZXRfYnJlYWtwb2ludHETiVgLAAAAdGltZV9ib3VuZHNxFF1xFShLAEsCZVgHAAAA
dmVyYm9zZXEWiXUu
</properties>
		<properties format="pickle" node_id="6">gAN9cQAoWA0AAABhYnNvbHV0ZV90aW1lcQGJWA0AAABhbHdheXNfb25fdG9wcQKJWAsAAABhbnRp
YWxpYXNlZHEDiFgQAAAAYXV0b19saW5lX2NvbG9yc3EEiVgJAAAAYXV0b3NjYWxlcQWIWBAAAABi
YWNrZ3JvdW5kX2NvbG9ycQZYBwAAACNGRkZGRkZxB1gQAAAAZGVjb3JhdGlvbl9jb2xvcnEIWAcA
AAAjMDAwMDAwcQlYCwAAAGRvd25zYW1wbGVkcQqJWAwAAABpbml0aWFsX2RpbXNxC11xDChLMksy
TbwCTfQBZVgKAAAAbGluZV9jb2xvcnENWAcAAAAjMDAwMDAwcQ5YCgAAAGxpbmVfd2lkdGhxD0c/
6AAAAAAAAFgMAAAAbWFya2VyX2NvbG9ycRBYBwAAACNGRjAwMDBxEVgMAAAAbmFuc19hc196ZXJv
cRKJWA4AAABub19jb25jYXRlbmF0ZXETiVgOAAAAb3ZlcnJpZGVfc3JhdGVxFFgNAAAAKHVzZSBk
ZWZhdWx0KXEVWAwAAABwbG90X21hcmtlcnNxFolYCwAAAHBsb3RfbWlubWF4cReJWBMAAABzYXZl
ZFdpZGdldEdlb21ldHJ5cRhjc2lwCl91bnBpY2tsZV90eXBlCnEZWAwAAABQeVF0NC5RdENvcmVx
GlgKAAAAUUJ5dGVBcnJheXEbQy4B2dDLAAEAAAAAAwMAAAEPAAAEfAAAAs8AAAMMAAABNQAABHMA
AALGAAAAAAAAcRyFcR2HcR5ScR9YBQAAAHNjYWxlcSBHP/AAAAAAAABYDgAAAHNldF9icmVha3Bv
aW50cSGJWAwAAABzaG93X3Rvb2xiYXJxIolYCwAAAHN0cmVhbV9uYW1lcSNYDQAAACh1c2UgZGVm
YXVsdClxJFgKAAAAdGltZV9yYW5nZXElSwJYBQAAAHRpdGxlcSZYEAAAAFRpbWUgc2VyaWVzIHZp
ZXdxJ1gKAAAAemVyb19jb2xvcnEoWAcAAAAjN0Y3RjdGcSlYCAAAAHplcm9tZWFucSqIdS4=
</properties>
		<properties format="pickle" node_id="7">gAN9cQAoWA0AAABhbnRpc3ltbWV0cmljcQGJWAQAAABheGlzcQJYBAAAAHRpbWVxA1gSAAAAY29u
dm9sdXRpb25fbWV0aG9kcQRYCAAAAHN0YW5kYXJkcQVYDgAAAGN1dF9wcmVyaW5naW5ncQaJWAsA
AABmcmVxdWVuY2llc3EHXXEIKEc/uZmZmZmZmksBS0ZHQFG5mZmZmZplWA0AAABtaW5pbXVtX3Bo
YXNlcQmIWAQAAABtb2RlcQpYCAAAAGJhbmRwYXNzcQtYBQAAAG9yZGVycQxYDQAAACh1c2UgZGVm
YXVsdClxDVgTAAAAc2F2ZWRXaWRnZXRHZW9tZXRyeXEOY3NpcApfdW5waWNrbGVfdHlwZQpxD1gM
AAAAUHlRdDQuUXRDb3JlcRBYCgAAAFFCeXRlQXJyYXlxEUMuAdnQywABAAAAAAMDAAABigAABHwA
AAJUAAADDAAAAbAAAARzAAACSwAAAAAAAHEShXETh3EUUnEVWA4AAABzZXRfYnJlYWtwb2ludHEW
iVgKAAAAc3RvcF9hdHRlbnEXR0BJAAAAAAAAdS4=
</properties>
		<properties format="pickle" node_id="8">gAN9cQAoWBMAAABiYW5kd2lkdGhfZnJlcXVlbmN5cQFLBVgRAAAAY2VudHJhbF9mcmVxdWVuY3lx
Akc/+AAAAAAAAFgTAAAAc2F2ZWRXaWRnZXRHZW9tZXRyeXEDY3NpcApfdW5waWNrbGVfdHlwZQpx
BFgMAAAAUHlRdDQuUXRDb3JlcQVYCgAAAFFCeXRlQXJyYXlxBkMuAdnQywABAAAAAAMDAAABfAAA
BHwAAAJiAAADDAAAAaIAAARzAAACWQAAAAAAAHEHhXEIh3EJUnEKWAsAAABzY2FsZV9yYW5nZXEL
XXEMKEsBSxRlWA4AAABzZXRfYnJlYWtwb2ludHENiVgHAAAAd2F2ZWxldHEOWAQAAABtb3JscQ91
Lg==
</properties>
		<properties format="pickle" node_id="9">gAN9cQAoWA0AAABhYnNvbHV0ZV90aW1lcQGIWA0AAABhbHdheXNfb25fdG9wcQKJWAsAAABhbnRp
YWxpYXNlZHEDiFgQAAAAYXV0b19saW5lX2NvbG9yc3EEiVgJAAAAYXV0b3NjYWxlcQWIWBAAAABi
YWNrZ3JvdW5kX2NvbG9ycQZYBwAAACNGRkZGRkZxB1gQAAAAZGVjb3JhdGlvbl9jb2xvcnEIWAcA
AAAjMDAwMDAwcQlYCwAAAGRvd25zYW1wbGVkcQqJWAwAAABpbml0aWFsX2RpbXNxC11xDChLMksy
TbwCTfQBZVgKAAAAbGluZV9jb2xvcnENWAcAAAAjMDAwMDAwcQ5YCgAAAGxpbmVfd2lkdGhxD0c/
6AAAAAAAAFgMAAAAbWFya2VyX2NvbG9ycRBYBwAAACNGRjAwMDBxEVgMAAAAbmFuc19hc196ZXJv
cRKJWA4AAABub19jb25jYXRlbmF0ZXETiVgOAAAAb3ZlcnJpZGVfc3JhdGVxFFgNAAAAKHVzZSBk
ZWZhdWx0KXEVWAwAAABwbG90X21hcmtlcnNxFolYCwAAAHBsb3RfbWlubWF4cReJWBMAAABzYXZl
ZFdpZGdldEdlb21ldHJ5cRhjc2lwCl91bnBpY2tsZV90eXBlCnEZWAwAAABQeVF0NC5RdENvcmVx
GlgKAAAAUUJ5dGVBcnJheXEbQy4B2dDLAAEAAAAAAwMAAAEPAAAEfAAAAs8AAAMMAAABNQAABHMA
AALGAAAAAAAAcRyFcR2HcR5ScR9YBQAAAHNjYWxlcSBHP/AAAAAAAABYDgAAAHNldF9icmVha3Bv
aW50cSGJWAwAAABzaG93X3Rvb2xiYXJxIolYCwAAAHN0cmVhbV9uYW1lcSNYDQAAACh1c2UgZGVm
YXVsdClxJFgKAAAAdGltZV9yYW5nZXElSwJYBQAAAHRpdGxlcSZYBAAAAGN0ZnRxJ1gKAAAAemVy
b19jb2xvcnEoWAcAAAAjN0Y3RjdGcSlYCAAAAHplcm9tZWFucSqIdS4=
</properties>
		<properties format="pickle" node_id="10">gAN9cQAoWAwAAABhbGxvd19kb3VibGVxAYlYDwAAAGNsb3NlX29uX21hcmtlcnECWA8AAABjbG9z
ZS1yZWNvcmRpbmdxA1gNAAAAY2xvdWRfYWNjb3VudHEEWAAAAABxBVgMAAAAY2xvdWRfYnVja2V0
cQZoBVgRAAAAY2xvdWRfY3JlZGVudGlhbHNxB2gFWAoAAABjbG91ZF9ob3N0cQhYBwAAAERlZmF1
bHRxCVgOAAAAY2xvdWRfcGFydHNpemVxCkseWAwAAABkZWxldGVfcGFydHNxC4hYCAAAAGZpbGVu
YW1lcQxYLwAAAEQ6L0VtbWFudWVsX3BldHJvbl9PbGF0ZWp1L01NTl9TWi9leHRlcm5hbHMueGRm
cQ1YCwAAAG91dHB1dF9yb290cQ5oBVgLAAAAcmV0cmlldmFibGVxD4lYEwAAAHNhdmVkV2lkZ2V0
R2VvbWV0cnlxEGNzaXAKX3VucGlja2xlX3R5cGUKcRFYDAAAAFB5UXQ0LlF0Q29yZXESWAoAAABR
Qnl0ZUFycmF5cRNDLgHZ0MsAAQAAAAADAwAAASMAAAR8AAACuwAAAwwAAAFJAAAEcwAAArIAAAAA
AABxFIVxFYdxFlJxF1gNAAAAc2Vzc2lvbl9ub3Rlc3EYaAVYDgAAAHNldF9icmVha3BvaW50cRmJ
WAcAAAB2ZXJib3NlcRqJdS4=
</properties>
		<properties format="pickle" node_id="11">gAN9cQAoWBcAAABhYnNvbHV0ZV9pbnN0YW5jZV90aW1lc3EBiFgNAAAAY2xvdWRfYWNjb3VudHEC
WAAAAABxA1gMAAAAY2xvdWRfYnVja2V0cQRoA1gRAAAAY2xvdWRfY3JlZGVudGlhbHNxBWgDWAoA
AABjbG91ZF9ob3N0cQZYBwAAAERlZmF1bHRxB1gNAAAAY29sdW1uX2hlYWRlcnEIiFgMAAAAZGVs
ZXRlX3BhcnRzcQmIWAgAAABmaWxlbmFtZXEKWCoAAABEOi9FbW1hbnVlbF9wZXRyb25fT2xhdGVq
dS9NTU5fU1ovY3RmdC5jc3ZxC1gLAAAAb3V0cHV0X3Jvb3RxDGgDWAsAAAByZXRyaWV2YWJsZXEN
iVgTAAAAc2F2ZWRXaWRnZXRHZW9tZXRyeXEOY3NpcApfdW5waWNrbGVfdHlwZQpxD1gMAAAAUHlR
dDQuUXRDb3JlcRBYCgAAAFFCeXRlQXJyYXlxEUMuAdnQywABAAAAAAMDAAABSgAABHwAAAKUAAAD
DAAAAXAAAARzAAACiwAAAAAAAHEShXETh3EUUnEVWA4AAABzZXRfYnJlYWtwb2ludHEWiVgLAAAA
dGltZV9zdGFtcHNxF4hYDwAAAHRpbWVzdGFtcF9sYWJlbHEYWAkAAAB0aW1lc3RhbXBxGXUu
</properties>
	</node_properties>
	<patch>{
    "description": {
        "description": "(description missing)",
        "license": "",
        "name": "(untitled)",
        "status": "(unspecified)",
        "url": "",
        "version": "0.0.0"
    },
    "edges": [
        [
            "node1",
            "data",
            "node4",
            "data"
        ],
        [
            "node5",
            "data",
            "node3",
            "data"
        ],
        [
            "node3",
            "data",
            "node8",
            "data"
        ],
        [
            "node8",
            "data",
            "node6",
            "data"
        ],
        [
            "node8",
            "data",
            "node2",
            "data"
        ],
        [
            "node6",
            "data",
            "node7",
            "data"
        ],
        [
            "node6",
            "data",
            "node1",
            "data"
        ],
        [
            "node6",
            "data",
            "node9",
            "data"
        ],
        [
            "node9",
            "data",
            "node10",
            "data"
        ],
        [
            "node9",
            "data",
            "node12",
            "data"
        ]
    ],
    "nodes": {
        "node1": {
            "class": "WelchSpectrum",
            "module": "neuropype.nodes.spectral.WelchSpectrum",
            "params": {
                "average_over_time_window": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "axis": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "time"
                },
                "detrend": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "constant"
                },
                "fft_size": {
                    "customized": false,
                    "type": "IntPort",
                    "value": null
                },
                "onesided": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "overlap_samples": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": null
                },
                "scaling": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "density"
                },
                "segment_samples": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": null
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "unit": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "samples"
                },
                "window": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "hann"
                }
            },
            "uuid": "6c6df3ef-888f-4ce8-8e54-d4a77100096e"
        },
        "node10": {
            "class": "TimeSeriesPlot",
            "module": "neuropype.nodes.visualization.TimeSeriesPlot",
            "params": {
                "absolute_time": {
                    "customized": true,
                    "type": "BoolPort",
                    "value": true
                },
                "always_on_top": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "antialiased": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "auto_line_colors": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "autoscale": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "background_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#FFFFFF"
                },
                "decoration_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#000000"
                },
                "downsampled": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "initial_dims": {
                    "customized": false,
                    "type": "ListPort",
                    "value": [
                        50,
                        50,
                        700,
                        500
                    ]
                },
                "line_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#000000"
                },
                "line_width": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.75
                },
                "marker_color": {
                    "customized": false,
                    "type": "Port",
                    "value": "#FF0000"
                },
                "nans_as_zero": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "no_concatenate": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "override_srate": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": null
                },
                "plot_markers": {
                    "customized": true,
                    "type": "BoolPort",
                    "value": false
                },
                "plot_minmax": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "scale": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 1.0
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "show_toolbar": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "stream_name": {
                    "customized": false,
                    "type": "StringPort",
                    "value": null
                },
                "time_range": {
                    "customized": true,
                    "type": "FloatPort",
                    "value": 2
                },
                "title": {
                    "customized": true,
                    "type": "StringPort",
                    "value": "ctft"
                },
                "zero_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#7F7F7F"
                },
                "zeromean": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                }
            },
            "uuid": "05058dd1-ad89-425e-a333-bc4fbd6f8110"
        },
        "node11": {
            "class": "RecordToXDF",
            "module": "neuropype.nodes.file_system.RecordToXDF",
            "params": {
                "allow_double": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "close_on_marker": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "close-recording"
                },
                "cloud_account": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_bucket": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_credentials": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_host": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "Default"
                },
                "cloud_partsize": {
                    "customized": false,
                    "type": "IntPort",
                    "value": 30
                },
                "delete_parts": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "filename": {
                    "customized": true,
                    "type": "StringPort",
                    "value": "D:/Emmanuel_petron_Olateju/MMN_SZ/externals.xdf"
                },
                "output_root": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "retrievable": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "session_notes": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "verbose": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                }
            },
            "uuid": "da02cc0a-6859-45a7-a661-b390f1221482"
        },
        "node12": {
            "class": "RecordToCSV",
            "module": "neuropype.nodes.file_system.RecordToCSV",
            "params": {
                "absolute_instance_times": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "cloud_account": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_bucket": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_credentials": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_host": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "Default"
                },
                "column_header": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "delete_parts": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "filename": {
                    "customized": true,
                    "type": "StringPort",
                    "value": "D:/Emmanuel_petron_Olateju/MMN_SZ/ctft.csv"
                },
                "output_root": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "retrievable": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "time_stamps": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "timestamp_label": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "timestamp"
                }
            },
            "uuid": "81c8d872-d0c9-4503-96eb-918cfa59e3a3"
        },
        "node2": {
            "class": "RecordToXDF",
            "module": "neuropype.nodes.file_system.RecordToXDF",
            "params": {
                "allow_double": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "close_on_marker": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "close-recording"
                },
                "cloud_account": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_bucket": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_credentials": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_host": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "Default"
                },
                "cloud_partsize": {
                    "customized": false,
                    "type": "IntPort",
                    "value": 30
                },
                "delete_parts": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "filename": {
                    "customized": true,
                    "type": "StringPort",
                    "value": "D:/Emmanuel_petron_Olateju/MMN_SZ/externals.xdf"
                },
                "output_root": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "retrievable": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "session_notes": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "verbose": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                }
            },
            "uuid": "9a1b2ddb-7164-4e23-aa56-0808ff2ee136"
        },
        "node3": {
            "class": "StreamData",
            "module": "neuropype.nodes.formatting.StreamData",
            "params": {
                "hitch_probability": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.0
                },
                "jitter_percent": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 5
                },
                "looping": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "randseed": {
                    "customized": false,
                    "type": "IntPort",
                    "value": 34535
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "speedup": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 1.0
                },
                "start_pos": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.0
                },
                "timestamp_jitter": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.0
                },
                "timing": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "wallclock"
                },
                "update_interval": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.04
                }
            },
            "uuid": "f04c7d6f-e827-4a1c-85fe-697fff6fe1a8"
        },
        "node4": {
            "class": "SpectrumPlot",
            "module": "neuropype.nodes.visualization.SpectrumPlot",
            "params": {
                "always_on_top": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "antialiased": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "autoscale": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "background_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#FFFFFF"
                },
                "decoration_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#000000"
                },
                "downsampled": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "initial_dims": {
                    "customized": false,
                    "type": "ListPort",
                    "value": [
                        50,
                        50,
                        700,
                        500
                    ]
                },
                "line_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#000000"
                },
                "line_width": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.75
                },
                "one_over_f_correction": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "scale": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 1.0
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "stacked": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "stream_name": {
                    "customized": false,
                    "type": "StringPort",
                    "value": null
                },
                "title": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "Spectrum view"
                },
                "zero_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#7F7F7F7F"
                }
            },
            "uuid": "c3bf8d79-0b4a-4074-9343-efde6ec6f38e"
        },
        "node5": {
            "class": "ImportXDF",
            "module": "neuropype.nodes.file_system.ImportXDF",
            "params": {
                "cloud_account": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_bucket": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_credentials": {
                    "customized": false,
                    "type": "StringPort",
                    "value": ""
                },
                "cloud_host": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "Default"
                },
                "filename": {
                    "customized": true,
                    "type": "StringPort",
                    "value": "D:/Emmanuel_petron_Olateju/MMN_SZ/12.xdf"
                },
                "handle_clock_resets": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "handle_clock_sync": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "handle_jitter_removal": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "max_marker_len": {
                    "customized": false,
                    "type": "IntPort",
                    "value": null
                },
                "reorder_timestamps": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "retain_streams": {
                    "customized": false,
                    "type": "Port",
                    "value": null
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "use_streamnames": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "verbose": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                }
            },
            "uuid": "fafcc49b-8462-43c4-bc9b-d1ea76d526d0"
        },
        "node6": {
            "class": "Segmentation",
            "module": "neuropype.nodes.formatting.Segmentation",
            "params": {
                "keep_marker_chunk": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "max_gap_length": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.2
                },
                "online_epoching": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "marker-locked"
                },
                "sample_offset": {
                    "customized": false,
                    "type": "IntPort",
                    "value": 0
                },
                "select_markers": {
                    "customized": true,
                    "type": "ListPort",
                    "value": [
                        "calib-begin",
                        "rest",
                        "active_movement"
                    ]
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "time_bounds": {
                    "customized": true,
                    "type": "ListPort",
                    "value": [
                        0,
                        2
                    ]
                },
                "verbose": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                }
            },
            "uuid": "850c360a-4f40-47c0-9c10-77acb7b8e0fb"
        },
        "node7": {
            "class": "TimeSeriesPlot",
            "module": "neuropype.nodes.visualization.TimeSeriesPlot",
            "params": {
                "absolute_time": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "always_on_top": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "antialiased": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "auto_line_colors": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "autoscale": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "background_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#FFFFFF"
                },
                "decoration_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#000000"
                },
                "downsampled": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "initial_dims": {
                    "customized": false,
                    "type": "ListPort",
                    "value": [
                        50,
                        50,
                        700,
                        500
                    ]
                },
                "line_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#000000"
                },
                "line_width": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 0.75
                },
                "marker_color": {
                    "customized": false,
                    "type": "Port",
                    "value": "#FF0000"
                },
                "nans_as_zero": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "no_concatenate": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "override_srate": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": null
                },
                "plot_markers": {
                    "customized": true,
                    "type": "BoolPort",
                    "value": false
                },
                "plot_minmax": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "scale": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 1.0
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "show_toolbar": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "stream_name": {
                    "customized": false,
                    "type": "StringPort",
                    "value": null
                },
                "time_range": {
                    "customized": true,
                    "type": "FloatPort",
                    "value": 2
                },
                "title": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "Time series view"
                },
                "zero_color": {
                    "customized": false,
                    "type": "StringPort",
                    "value": "#7F7F7F"
                },
                "zeromean": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                }
            },
            "uuid": "3e245a16-09da-4817-94df-03f1966a4163"
        },
        "node8": {
            "class": "FIRFilter",
            "module": "neuropype.nodes.signal_processing.FIRFilter",
            "params": {
                "antisymmetric": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "axis": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "time"
                },
                "convolution_method": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "standard"
                },
                "cut_preringing": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "frequencies": {
                    "customized": true,
                    "type": "ListPort",
                    "value": [
                        0.1,
                        1,
                        70,
                        70.9
                    ]
                },
                "minimum_phase": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": true
                },
                "mode": {
                    "customized": false,
                    "type": "EnumPort",
                    "value": "bandpass"
                },
                "order": {
                    "customized": false,
                    "type": "IntPort",
                    "value": null
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "stop_atten": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 50.0
                }
            },
            "uuid": "f2860839-b8ca-4402-a2b6-4c599cb4153f"
        },
        "node9": {
            "class": "ContinuousWaveletTransform",
            "module": "neuropype.nodes.spectral.ContinuousWaveletTransform",
            "params": {
                "bandwidth_frequency": {
                    "customized": true,
                    "type": "FloatPort",
                    "value": 5
                },
                "central_frequency": {
                    "customized": false,
                    "type": "FloatPort",
                    "value": 1.5
                },
                "scale_range": {
                    "customized": true,
                    "type": "ListPort",
                    "value": [
                        1,
                        20
                    ]
                },
                "set_breakpoint": {
                    "customized": false,
                    "type": "BoolPort",
                    "value": false
                },
                "wavelet": {
                    "customized": true,
                    "type": "EnumPort",
                    "value": "morl"
                }
            },
            "uuid": "8203bf5c-d33a-466c-986e-93e46074f4eb"
        }
    },
    "version": 1.1
}</patch>
</scheme>
