@mkdir Nugets
@mkdir Nugets\TrackerEnabledDbContext-4.0
@mkdir Nugets\TrackerEnabledDbContext-4.0\lib
@mkdir Nugets\TrackerEnabledDbContext-4.0\lib\net40

rem Merge two dlls together

ILMerge.exe /out:Nugets\TrackerEnabledDbContext-4.0\lib\net40\TrackerEnabledDbContext.dll /target:library /targetplatform:4.0,"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0" "TrackerEnabledDbContext\bin\Release\TrackerEnabledDbContext.dll" "TrackerEnabledDbContext\bin\Release\TrackerEnabledDbContext.Common.dll"

copy "TrackerEnabledDbContext-4.0.nuspec" Nugets\TrackerEnabledDbContext-4.0\

nuget pack Nugets\TrackerEnabledDbContext-4.0\TrackerEnabledDbContext-4.0.nuspec

copy Nugets\TrackerEnabledDbContext-4.0\lib\net40\TrackerEnabledDbContext.dll "E:\AuthAir\Nick's Playground\src\Entity\EntityTrackerEnabledDBContext\packages\TrackerEnabledDbContext-4.0.1.0.4\lib\net40\"

copy Nugets\TrackerEnabledDbContext-4.0\lib\net40\TrackerEnabledDbContext.dll "E:\AuthAir\AuthAir Dental\feature\nb-2016-10-11-2.0.1\packages\TrackerEnabledDbContext-4.0.1.0.4\lib\net40\"

